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
using System.Collections;
using System.Xml.Serialization;

namespace Stockii
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string curSearchName = "";
        private string curGroupName = "";
        private List<string> curStockIds = new List<string>();
        private string curApiName = "";
        
        private Dictionary<string, string> curPages = new Dictionary<string, string>();
        private Dictionary<string, string> totalPages = new Dictionary<string, string>();
        

        public MainForm()
        {
            InitializeComponent();
            if (!Commons.InitCommons())
                System.Environment.Exit(1);
            
            InitSearch();
            InitGroupInfo();
            InitGroupMenu();
            InitAreaMenu();
            InitIndustryMenu();
            customXtraGrid1.gridControl1.DataSource = Commons.dataSet;

            //创建配置文件目录
            if (!Directory.Exists(Constants.configDir))
            {
                Directory.CreateDirectory(Constants.configDir);
            }
            if (File.Exists(Constants.dockLayoutPath))
            {
                dockManager1.RestoreLayoutFromXml(Constants.dockLayoutPath);
            }
            calTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            
        }

        private void InitIndustryMenu()
        {
            foreach (string name in Commons.industryDict.Keys)
            {
                AddToMenu(industryMenu, name);
            }
        }

        private void InitAreaMenu()
        {
            foreach (string name in Commons.areaDict.Keys)
            {
                AddToMenu(areaMenu, name);
            }
        }

        private void InitGroupMenu()
        {
            if (File.Exists(Constants.groupConfigPath))
            {
                using (FileStream fileStream = new FileStream(Constants.groupConfigPath, FileMode.Open))
                {
                    XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, List<string>>));
                    Commons.groupDict = (SerializableDictionary<string, List<string>>)xmlFormatter.Deserialize(fileStream);
                }
                foreach (string groupName in Commons.groupDict.Keys)
                {
                    AddToMenu(groupMenu, groupName);
                }
                if (groupMenu.ItemLinks.Count > 0)
                {
                    groupMenu.ItemLinks[0].Item.PerformClick();
                }
            }
        }

        private void InitGroupInfo()
        {
            if (curGroupName.Trim().Length != 0)
            {
                groupInfoPanel.Text = curGroupName;
            }
            groupListBox.Items.Clear();
            groupListBox.Items.AddRange(curStockIds.ToArray());
        }

        private void InitSearch()
        {
            foreach (XtraTabPage page in calTabControl.TabPages)
            {
                curPages[page.Name] = "1";
                totalPages[page.Name] = "1";
                Commons.dataSet.Tables.Add(new DataTable(page.Name));
            }
            curSearchName = calTabControl.SelectedTabPage.Name;
            BindData(Commons.dataSet.Tables[curSearchName]);
            {   // 初始化NDay的Tab
                nDayIndexCombo.Properties.Items.AddRange(Constants.nDayIndexDict.Keys);
                nDayIndexCombo.SelectedIndex = 0;
                nDayTypeCombo.Properties.Items.AddRange(Constants.nDayTypeDict.Keys);
                nDayTypeCombo.SelectedIndex = 0;
                nDaySumRadio.SelectedIndex = 0;
            }
            {   // 初始化自定义计算的Tab
                calTypeCombo.Properties.Items.AddRange(Constants.customCalTypeDict.Keys);
                calTypeCombo.SelectedIndex = 0;
                calIndexCombo.Properties.Items.AddRange(Constants.customCalIndexDict.Keys);
                calIndexCombo.SelectedIndex = 0;
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
            DataTable dt = ds.Tables[0].Copy();
            dt.TableName = curSearchName;
            if (Commons.dataSet.Tables.Contains(curSearchName))
            {
                Commons.dataSet.Tables.Remove(curSearchName);
            }
            Commons.dataSet.Tables.Add(dt);
            totalPages[curSearchName] = totalPage.ToString();
            BindData(dt);
            

            pageLabel.Text = curPages[curSearchName] + "/" + totalPages[curSearchName];
            CloseWaitForm();
            
        }

        private void BindData(DataTable dt)
        {
            customXtraGrid1.gridView1.Columns.Clear();
            customXtraGrid1.gridControl1.DataSource = dt;
            RenameColumnHeader();
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
            #region 判断时间是否有效
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
            #endregion
            string startDate = startDateEdit.DateTime.ToString("yyyy-MM-dd");
            string endDate = endDateEdit.DateTime.ToString("yyyy-MM-dd");
            if (curStockIds.Count != 0)
            {
                args["stockid"] = string.Join(",", curStockIds.ToArray());
            }          
            
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
                case "customCalTab":
                    string opt = Constants.customCalTypeDict[calTypeCombo.Text];
                    string optName = Constants.customCalIndexDict[calIndexCombo.Text];
                    switch (opt)
	                {
                        case "seperate":
                            curApiName = "listgrowthampdis";
                            break;
                        case "sum":
                            curApiName = "listndayssum";
                            args["sumname"] = optName;
                            break;
		                default:
                            curApiName = "liststockdaysdiff";
                            args["optname"] = optName;
                            args["opt"] = opt;
                            break;
	                }
                    args["pagesize"] = "10000";
                    
                    break;
                default:
                    break;
            }
            
            args["command"] = curApiName;
            args["starttime"] = startDate;
            args["endtime"] = endDate;
            args["page"] = "1";
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
            dockManager1.SaveLayoutToXml(Constants.dockLayoutPath);
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
                saveDialog.Filter = "Excel (2010)|*.xlsx|Csv File|*.csv|RichText File|*.rtf|Pdf File|*.pdf|Html File|*.html";
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
            BindData(Commons.dataSet.Tables[curSearchName]);
            pageLabel.Text = curPages[curSearchName] + "/" + totalPages[curSearchName];
        }

        private void newGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<string> stockIds;
            string groupName = GroupDialog.GetSelectStock(out stockIds);
            if (groupName != null)
            {
                curGroupName = "自选:" + groupName;
                curStockIds = stockIds;
                AddToMenu(groupMenu, groupName);
            }
        }

        private void AddToMenu(PopupMenu menu, string groupName)
        {
            if (groupName.Length == 0)
            {
                return;
            }
            BarCheckItem item = new BarCheckItem();
                
            item.ItemClick += new ItemClickEventHandler(this.menuItem_ItemClick);
            item.Caption = groupName;
            item.Tag = menu.Name;
            menu.AddItem(item);
            Commons.menuItems.Add(item);
            if (menu.Name == "groupMenu")
            {
                Commons.SaveGroup();
            }
        }

        private void menuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarCheckItem item;
            foreach (BarCheckItem menuItem in Commons.menuItems)
            {
                menuItem.Checked = false;
            }
            item = e.Item as BarCheckItem;
            item.Checked = true;
            switch (item.Tag as string)
            {
                case "groupMenu":
                    curGroupName = "自选: " + item.Caption;
                    curStockIds = Commons.groupDict[item.Caption];
                    break;
                case "areaMenu":
                    curGroupName = "地区: " + item.Caption;
                    curStockIds = Commons.areaDict[item.Caption];
                    break;
                case "industryMenu":
                    curGroupName = "行业: " + item.Caption;
                    curStockIds = Commons.industryDict[item.Caption];
                    break;
                default:
                    break;
            }
            InitGroupInfo();
        }

        private void editGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GroupDialog.EditStock();
        }
    }
}