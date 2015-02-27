using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Columns;

namespace Stockii
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string curSearchName = "";
        private List<string> curStockIds = new List<string>();
        private string curApiName = "";
        private string dockLayoutPath = "dockLayout.xml";
        private Dictionary<string, string> curPages = new Dictionary<string, string>();
        private Dictionary<string, string> totalPages = new Dictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();
            InitSearch();
            customXtraGrid1.gridControl1.DataSource = Commons.dataSet;
            if (File.Exists(dockLayoutPath))
            {
                dockManager1.RestoreLayoutFromXml(dockLayoutPath);
            }
            calTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;


            //DataTable dt = new DataTable("hello");
            //int colN = 5;
            //int rowN = 10000;
            //for (int i = 0; i < colN; i++)
            //{
            //    dt.Columns.Add(string.Format("colxxxxxxxxxxxxxxxxxxxxxumn{0}", i), 3.GetType());
            //}
            //for (int i = 0; i < rowN; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    for (int j = 0; j < colN; j++)
            //    {
            //        dr[string.Format("colxxxxxxxxxxxxxxxxxxxxxumn{0}", j)] = i + j;
            //    }
            //    dt.Rows.Add(dr);
            //}
            ////System.Threading.Thread.Sleep(3000);

            ////gridView1.DataSource = dt;
            //customXtraGrid1.gridControl1.DataSource = dt;
        }

        private void InitSearch()
        {
            foreach (XtraTabPage page in calTabControl.TabPages)
            {
                curPages[page.Name] = "1";
                totalPages[page.Name] = "1";
            }
            curSearchName = nDayCalTab.Name;
            {   // 初始化NDay 的Tab
                nDayIndexCombo.Properties.Items.AddRange(Constants.nDayIndexDict.Keys);
                nDayIndexCombo.SelectedIndex = 0;
                nDayTypeCombo.Properties.Items.AddRange(Constants.nDayTypeDict.Keys);
                nDayTypeCombo.SelectedIndex = 0;
                nDaySumRadio.SelectedIndex = 0;
            }
            
        }

        private void ShowWaitForm()
        {
            if (!splashScreenManager2.IsSplashFormVisible)
            {
                splashScreenManager2.ShowWaitForm();
            }
            
            //this.Enabled = false;
          
        }

        private void CloseWaitForm()
        {
            if (splashScreenManager2.IsSplashFormVisible)
            {
                splashScreenManager2.CloseWaitForm();
            }
            //this.Enabled = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            nDayCalTab.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            customCalTab.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> args = getSearchArgs(curSearchName);
            if (args == null)
            {
                return;
            }
            ShowWaitForm();
            int totalPage;
            DataSet ds;
            JSONHandler.CallApi(args, out totalPage, out ds);
            ds.Tables[0].TableName = curSearchName;
            if (Commons.dataSet.Tables.Contains(curSearchName))
            {
                Commons.dataSet.Tables.Remove(curSearchName);
            }
            Commons.dataSet.Tables.Add(ds.Tables[0].Copy());
            
            totalPages[curSearchName] = totalPage.ToString();
            customXtraGrid1.gridControl1.DataMember = curSearchName;
            RenameColumnHeader();

            pageLabel.Text = curPages[curSearchName] + "/" + totalPages[curSearchName];
            CloseWaitForm();
            
        }

        private void RenameColumnHeader()
        {
            foreach (GridColumn column in customXtraGrid1.gridView1.Columns)
            {
                if (Constants.translateDict.Keys.Contains(column.FieldName))
                {
                    column.Caption = Constants.translateDict[column.FieldName];
                }
            }
        }

        private Dictionary<string, string> getSearchArgs(string searchName)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            /*
            if (startDateEdit.DateTime > endDateEdit.DateTime)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("开始时间大于结束时间，请重新输入");
                return null;
            }
            if (!Commons.IsTradeDay(startDateEdit.DateTime))
            {
                //TODO
                DevExpress.XtraEditors.XtraMessageBox.Show("开始时间非交易日，请重新输入");
                return null;
            }
            if (!Commons.IsTradeDay(endDateEdit.DateTime))
            {
                //TODO
                DevExpress.XtraEditors.XtraMessageBox.Show("结束时间非交易日，请重新输入");
                return null;
            }
            //*/
            string startDate = startDateEdit.DateTime.ToString("yyyy-MM-dd");
            string endDate = endDateEdit.DateTime.ToString("yyyy-MM-dd");
            if (curStockIds.Count != 0)
            {
                args["stockid"] = string.Join(",", curStockIds.ToArray());
            }          
            args["starttime"] = startDate;
            args["endtime"] = endDate;
            
            switch (searchName)
            {
                case "nDayCalTab":
                    switch (nDaySumRadio.SelectedIndex)
	                {
                        case 1:
                            curApiName = "listweeksum";
                            args["weeks"] = nDayCountSpin.Text;
                            break;
                        case 2:
                            curApiName = "listmonthssum";
                            args["months"] = nDayCountSpin.Text;
                            break;
                        default:
                            curApiName = "listdaysum";
                            args["days"] = nDayCountSpin.Text;
                            break;
	                }
                    args["pagesize"] = "1000";
                    args["sumname"] = Constants.nDayIndexDict[nDayIndexCombo.Text];
                    args["sumtype"] = Constants.nDayTypeDict[nDayTypeCombo.Text];
                    break;
                default:
                    break;
            }
            args["page"] = "1";
            args["command"] = curApiName;
            args["response"] = "json";
            return args;
        }

        private void nDaySumRadio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int min = 1;
            int max = 1;
            switch (nDaySumRadio.SelectedIndex)
            {
                case 0:
                    min = 3;
                    max = 30;
                    break;
                case 1:
                    min = 1;
                    max = 7;
                    break;
                case 2:
                    min = 1;
                    max = 12;
                    break;
                default:
                    break;
            }
            nDayCountSpin.Properties.MaxValue = max;
            nDayCountSpin.Properties.MinValue = min;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockManager1.SaveLayoutToXml(dockLayoutPath);
        }

        private void tradeDatesEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (autoCalDateCombo.SelectedIndex == 0)
            {
                //TODO
                DateTime startDate = startDateEdit.DateTime;
                try
                {
                    DateTime endDate = startDate.AddDays(Convert.ToDouble(e.NewValue));
                    endDateEdit.DateTime = endDate;
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show("超出交易日范围");
                }
                
            }
            else 
            {
                //TODO
                DateTime endDate = endDateEdit.DateTime;
                try
                {
                    DateTime startDate = endDate.AddDays(-Convert.ToDouble(e.NewValue));
                    startDateEdit.DateTime = endDate;
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show("超出交易日范围");
                }
            }
        }

        private void printItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWaitForm();
            //System.Threading.Thread.Sleep(3000);
            //CloseWaitForm();
            customXtraGrid1.gridControl1.ShowPrintPreview();
        }

        private void dumpItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region 导出
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |Csv File (.csv)|*.csv |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xlsx":
                            customXtraGrid1.gridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".csv":
                            customXtraGrid1.gridControl1.ExportToCsv(exportFilePath);
                            break;
                        case ".rtf":
                            customXtraGrid1.gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            customXtraGrid1.gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            customXtraGrid1.gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            customXtraGrid1.gridControl1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                }
            }
            #endregion
        }

        private void calTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            curSearchName = e.Page.Name;
            customXtraGrid1.gridControl1.DataMember = curSearchName;
            pageLabel.Text = curPages[curSearchName] + "/" + totalPages[curSearchName];
        }

        private void newGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}