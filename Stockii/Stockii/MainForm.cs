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
        private CustomPage curPage = null;
        public MainForm()
        {
            InitializeComponent();
            if (!Commons.InitCommons())
                System.Environment.Exit(1);
            
            InitGroupMenu();
            InitAreaMenu();
            InitIndustryMenu();
            
            //创建配置文件目录
            if (!Directory.Exists(Constants.configDir))
            {
                Directory.CreateDirectory(Constants.configDir);
            }
            if (File.Exists(Constants.dockLayoutPath))
            {
                //dockManager1.RestoreLayoutFromXml(Constants.dockLayoutPath);
            }
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
            }
        }

        public void ShowWaitForm()
        {
            if (!splashScreenManager2.IsSplashFormVisible)
            {
                splashScreenManager2.ShowWaitForm();
            }
            
            //this.Enabled = false;
          
        }

        public void CloseWaitForm()
        {
            if (splashScreenManager2.IsSplashFormVisible)
            {
                splashScreenManager2.CloseWaitForm();
            }
            //this.Enabled = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage xpage = new XtraTabPage();
            CustomPage page = new CustomPage(this, "nDayCalTab");
            xpage.Text = "N日和";
            page.Dock = DockStyle.Fill;
            xpage.Controls.Add(page);//添加要增加的控件
            xtraTabControl1.TabPages.Add(xpage);
            xtraTabControl1.SelectedTabPage = xpage;//显示该页

            
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage xpage = new XtraTabPage();
            CustomPage page = new CustomPage(this, "customCalTab");
            xpage.Text = "自定义计算";
            page.Dock = DockStyle.Fill;
            xpage.Controls.Add(page);//添加要增加的控件
            xtraTabControl1.TabPages.Add(xpage);
            xtraTabControl1.SelectedTabPage = xpage;//显示该页
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockManager1.SaveLayoutToXml(Constants.dockLayoutPath);
        }

        private void printItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWaitForm();
            //System.Threading.Thread.Sleep(3000);
            //CloseWaitForm();
            //customXtraGrid1.gridControl1.ShowPrintPreview();
        }

        private void dumpItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //#region 导出
            //using (SaveFileDialog saveDialog = new SaveFileDialog())
            //{
            //    saveDialog.Filter = "Excel (2010)|*.xlsx|Csv File|*.csv|RichText File|*.rtf|Pdf File|*.pdf|Html File|*.html";
            //    if (saveDialog.ShowDialog() != DialogResult.Cancel)
            //    {
            //        string exportFilePath = saveDialog.FileName;
            //        string fileExtenstion = new FileInfo(exportFilePath).Extension;
            //        switch (fileExtenstion)
            //        {
            //            case ".xlsx":
            //                customXtraGrid1.gridControl1.ExportToXlsx(exportFilePath);
            //                break;
            //            case ".csv":
            //                customXtraGrid1.gridControl1.ExportToCsv(exportFilePath);
            //                break;
            //            case ".rtf":
            //                customXtraGrid1.gridControl1.ExportToRtf(exportFilePath);
            //                break;
            //            case ".pdf":
            //                customXtraGrid1.gridControl1.ExportToPdf(exportFilePath);
            //                break;
            //            case ".html":
            //                customXtraGrid1.gridControl1.ExportToHtml(exportFilePath);
            //                break;
            //            case ".mht":
            //                customXtraGrid1.gridControl1.ExportToMht(exportFilePath);
            //                break;
            //            default:
            //                break;
            //        }

            //    }
            //}
            //#endregion
        }

        private void newGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            string groupName = GroupDialog.NewGroup();
            if (groupName != null)
            {
                AddToMenu(groupMenu, groupName);
            }
        }

        private void AddToMenu(PopupMenu menu, string groupName)
        {
            if (groupName.Length == 0)
            {
                return;
            }

            BarSubItem item = new BarSubItem();
                
            item.ItemClick += new ItemClickEventHandler(this.menuItem_ItemClick);
            item.Caption = groupName;
            item.Tag = menu.Name;
            menu.AddItem(item);
        }

        private void menuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curPage == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("当前不存在任何查询");
                return;
            }
            BarSubItem item;
            item = e.Item as BarSubItem;
            switch (item.Tag as string)
            {
                case "groupMenu":
                    curPage.InitPage("自选: " + item.Caption, Commons.groupDict[item.Caption]);
                    break;
                case "areaMenu":
                    curPage.InitPage("地区: " + item.Caption, Commons.areaDict[item.Caption]);
                    break;
                case "industryMenu":
                    curPage.InitPage("行业: " + item.Caption, Commons.industryDict[item.Caption]);
                    break;
                default:
                    break;
            }
        }

        private void editGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GroupDialog.EditStock();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabControl tabControl = sender as XtraTabControl;
            XtraTabPage tabPage = tabControl.SelectedTabPage;
            tabPage.Hide();
            tabPage.Dispose();
            
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage page = e.Page;
            curPage = page.Controls[0] as CustomPage;
        }
    }
}