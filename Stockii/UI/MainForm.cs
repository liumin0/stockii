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
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Stockii.UI
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CustomPage curPage = null;
        private string upDownType = "";
        private GridControl curActiveGrid = null;
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
            if (upDownType.Equals("FLAG_UP__"))
            {
		        curPage.curStatusText = "向上跨区： " + e.Item.Caption;
	        }
            else
            {
                curPage.curStatusText = "向下跨区： " + e.Item.Caption;
            }
            ShowStatusInStatusBar(curPage.curStatusText);
            curPage.DoFilterSearch(upDownType + e.Item.Tag);
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

        /// <summary>
        /// 功能切换按钮响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null)
            {
                return;
            }
            XtraTabPage xpage = new XtraTabPage();
            string tableName = e.Item.Tag.ToString();
            CustomPage page = new CustomPage(this, tableName);
            if (curPage != null)
            {
                if (Commons.property.KeepTime == Property.CustomBool.是)
                {
                    DateTime start, end;
                    curPage.GetTime(out start, out end);
                    page.SetTime(start, end);
                }
                if (Commons.property.KeepGroup == Property.CustomBool.是)
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
                foreach (XtraTabPage pg in xtraTabControl1.TabPages) //判断tab的名称是否有重复
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
            curActiveGrid = page.GetGridControl();
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
            if (curActiveGrid != null)
            {
                curActiveGrid.ShowPrintPreview();
            }
        }

        private void dumpItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (curActiveGrid != null)
            {
                Export(curActiveGrid);
            }
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
                if (saveDialog.ShowDialog(this) != DialogResult.Cancel)
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
            try
            {
                curPage = page.Controls[0] as CustomPage;
                ShowStatusInStatusBar(curPage.curStatusText);
                updownPanelGroup.Visible = curPage.WillShowUpDown();
            }
            catch (Exception)
            {
            }
           
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            SettingDialog d = new SettingDialog();
            d.ShowDialog(this);
        }

        public void ShowResultInStatusBar(string text)
        {
            autoCalResult.Caption = text;
        }

        public void ShowStatusInStatusBar(string text)
        {
            statusText.Caption = text;
        }

        private void upBoardItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            upDownType = "FLAG_UP__";
        }

        private void downBoardItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            upDownType = "FLAG_DOWN__";
        }

        public void Combine(GridControl control, bool isSelect)
        {
            
            Commons.Combine(control, combineGrid, isSelect);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            DataTable table = combineGrid.DataSource as DataTable;
            combineView.Columns.Clear();
            combineGrid.DataSource = Commons.combineUndoTable;
            Commons.combineUndoTable = table;
            List<Commons.SavedAction> tmp = Commons.combineCurActions;
            Commons.combineCurActions = Commons.combineUndoActions;
            Commons.combineUndoActions = tmp;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            combineView.Columns.Clear();
            DataTable table = combineGrid.DataSource as DataTable;
            Commons.combineUndoTable = table;
            combineGrid.DataSource = null;
            Commons.combineCurActions.Clear();
        }

        private void combinePanel_Enter(object sender, EventArgs e)
        {
            curActiveGrid = combineGrid;
            combineCategory.Visible = true;
        }

        private void combinePanel_Leave(object sender, EventArgs e)
        {
            if (curPage != null)
            {
                curActiveGrid = curPage.GetGridControl();
            }
            combineCategory.Visible = false;
        }

        private void saveCombineItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAction saveDialog = new SaveAction();
            saveDialog.ShowDialog(this);
        }

        private void autoCombineItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            AutoCombine autoDialog = new AutoCombine(this);
            autoDialog.ShowDialog(this);
        }

        public void DoAutoCombine(string groupName, DateTime startTime, DateTime endTime, List<Commons.SavedAction> list)
        {
            ShowWaitForm();
            do
            {
                DataTable resultTable = combineGrid.DataSource as DataTable;
                int total = list.Count;
                int count = 1;
                foreach (Commons.SavedAction action in list)
                {
                    SetWaitMessage(null, string.Format("正在拼接{0}/{1}",count++, total));
                    Dictionary<string, string> args = new Dictionary<string, string>();
                    foreach (string key in action.args.Keys)
                    {
                        args[key] = action.args[key];
                    }
                    if (Commons.groupDict[groupName].Count > 0)
                    {
                        args["stockid"] = string.Join(",", Commons.groupDict[groupName].ToArray());
                    }
                    args["starttime"] = startTime.ToString("yyyy-MM-dd");
                    args["endtime"] = endTime.ToString("yyyy-MM-dd");
                    DataSet ds;
                    int totalPage;
                    bool ret = JSONHandler.CallApi(args, out totalPage, out ds);
                    if (ret)
                    {
                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt.Columns[i].ColumnName = action.headers[i];
                        }
                        if (resultTable == null)
                        {
                            resultTable = dt;
                        }
                        else
                        {
                            resultTable = Commons.CombineDt(dt, resultTable);
                        }
                    }
                }
                Commons.SaveToUndo(combineGrid);
                Commons.BindCombineData(combineGrid, resultTable);
            } while (false);
            CloseWaitForm();
        }

        public void SetWaitMessage(string caption, string description)
        {
            if (caption != null)
            {
                splashScreenManager2.SetWaitFormCaption(caption);
            }
            if (description != null)
            {
                splashScreenManager2.SetWaitFormDescription(description);
            }
            
        }

        private void combineView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridCommons.CustomDrawRowIndicator(this, sender, e);
        }

        private void combineView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridCommons.SelectionChanged(this, sender, e);
        }

        private void combineView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridCommons.AddFixMenu(sender, e);
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            RibbonManage rb = new RibbonManage(this);
            rb.ShowDialog(this);

            //BarButtonItem testItem = new BarButtonItem();
            //testItem.Caption = "新添加的";
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            //testItem.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem39.Glyph")));
            //testItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            //| DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            //testItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            //ribbonPageGroup5.ItemLinks.Add(testItem);

            //XtraTabPage xpage = new XtraTabPage();
            //xpage.Text = "hello";
            //UserControl obj = null;
            //try
            //{
            //    //载入dll
            //    Assembly ab = Assembly.LoadFrom("C:\\WorkSpace\\vs\\plugin\\plugin\\bin\\Debug\\plugin.dll");
            //    Type[] types = ab.GetTypes();
            //    foreach (Type t in types)
            //    {
            //        if (t.GetInterface("PlubginInterface") != null)
            //        {
            //            obj = ab.CreateInstance(t.FullName) as UserControl;
            //            break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            //    return;
            //}
            //obj.Dock = DockStyle.Fill;
            //xpage.Controls.Add(obj);//添加要增加的控件
            //xtraTabControl1.TabPages.Add(xpage);
            //xtraTabControl1.SelectedTabPage = xpage;//显示该页
        }
    }
}