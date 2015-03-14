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
using DevExpress.XtraGrid;
using DevExpress.Utils.Menu;

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
            InitUpDownMenu();
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

        private void InitUpDownMenu()
        {
            foreach (BarItemLink link in upMenu.ItemLinks)
            {
                BarItem item = link.Item;

                if (item is BarSubItem)
                {
                    BarSubItem subItem = item as BarSubItem;
                    foreach (BarItemLink subLink in subItem.ItemLinks)
                    {
                        subLink.Item.ItemClick += new ItemClickEventHandler(this.upDownClick);
                    }
                }
                else
                {
                    item.ItemClick += new ItemClickEventHandler(this.upDownClick);
                }
            }
        }

        private void upDownClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(sender);
            
            Console.WriteLine(e.Item.Tag);
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
            foreach (string groupName in Commons.groupDict.Keys)
            {
                AddToMenu(groupMenu, groupName);
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
            string tableName = e.Item.Tag.ToString();
            CustomPage page = new CustomPage(this, tableName);
            if (curPage != null)
            {
                if (Commons.property.KeepTime)
                {
                    DateTime start, end;
                    curPage.GetTime(out start, out end);
                    page.SetTime(start, end);
                }
                if (Commons.property.KeepGroup)
                {
                    string groupName;
                    List<string> stockIds;
                    curPage.GetGroup(out groupName, out stockIds);
                    page.SetGroup(groupName, stockIds);
                }
            }
            int count = 1;
            xpage.Text = e.Item.Caption;
            
            while (true)
            {
                bool ok = true;
                foreach (XtraTabPage pg in xtraTabControl1.TabPages)
                {
                    if (pg.Text.Equals(xpage.Text + count))
                    {
                        count++;
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    break;
                }
            }
            
            xpage.Text += count;
            page.Dock = DockStyle.Fill;
            xpage.Controls.Add(page);//添加要增加的控件
            xtraTabControl1.TabPages.Add(xpage);
            xtraTabControl1.SelectedTabPage = xpage;//显示该页
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockManager1.SaveLayoutToXml(Constants.dockLayoutPath);
            DialogResult ret = DevExpress.XtraEditors.XtraMessageBox.Show("确定退出程序？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret != DialogResult.OK)
            {
                e.Cancel = true;
            }
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
            
        }

        public void Print(GridControl grid)
        {
            grid.ShowPrintPreview();
        }

        public void Export(GridControl grid)
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
                            grid.ExportToXlsx(exportFilePath);
                            break;
                        case ".csv":
                            grid.ExportToCsv(exportFilePath);
                            break;
                        case ".rtf":
                            grid.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            grid.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            grid.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            grid.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                }
            }
            #endregion
        }

        private void newGroupItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            string groupName = GroupDialog.NewGroup();
            AddToGroupMenu(groupName);
        }

        public void AddToGroupMenu(string groupName)
        {
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

            BarButtonItem item = new BarButtonItem();
            
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
            BarButtonItem item;
            item = e.Item as BarButtonItem;
            switch (item.Tag as string)
            {
                case "groupMenu":
                    curPage.SetGroup("自选: " + item.Caption, Commons.groupDict[item.Caption]);
                    break;
                case "areaMenu":
                    curPage.SetGroup("地区: " + item.Caption, Commons.areaDict[item.Caption]);
                    break;
                case "industryMenu":
                    curPage.SetGroup("行业: " + item.Caption, Commons.industryDict[item.Caption]);
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
            DialogResult ret = DevExpress.XtraEditors.XtraMessageBox.Show("确定关闭 " + tabPage.Text + "?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.OK)
            {
                tabPage.Hide();
                tabPage.Dispose();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage page = e.Page;
            curPage = page.Controls[0] as CustomPage;
            updownPanelGroup.Visible = curPage.WillShowUpDown();
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            SettingDialog d = new SettingDialog();
            d.ShowDialog();
        }

        public void ShowTextInStatusBar(string text)
        {
            autoCalResult.Caption = text;
        }
    }
}