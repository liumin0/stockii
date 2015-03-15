using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;

namespace Stockii
{
    public partial class CustomPage : DevExpress.XtraEditors.XtraUserControl
    {
        private MainForm parentForm;
        private Dictionary<string, string> savedArgs = new Dictionary<string, string>();
        private List<string> curStockIds = new List<string>();
        private string curCalcType = "";
        private string curApiName = "";
        private string curGroupName = "";
        private int page = 1;
        private int totalPage = 1;
        private string curFilter = "";
        public string curStatusText = "";
        public CustomPage(MainForm mainForm, string calcType)
        {
            InitializeComponent();
            parentForm = mainForm;
            bool hasTabPage = false;
            foreach (var item in layoutControl1.HiddenItems)
            {
                if (item is LayoutControlGroup)
                {
                    LayoutControlGroup page = item as LayoutControlGroup;
                    if (page.Name.Equals(calcType))
                    {
                        page.RestoreFromCustomization();
                        page.Move(calTabControl, DevExpress.XtraLayout.Utils.InsertType.Bottom);
                        //calTabControl.AddTabPage(page);
                        break;
                    }
                }
            }
            foreach (LayoutControlGroup page in calTabControl.TabPages)
            {
                if (page.Name.Equals(calcType))
                {
                    calTabControl.SelectedTabPage = page;
                    hasTabPage = true;
                    break;
                }
            }
            if (!hasTabPage)
            {
                calTabControl.HideToCustomization();
            }
            curCalcType = calcType;
            InitSearch();
            InitGroupInfo();
            
        }

        public bool WillShowUpDown()
        {
            return Constants.customSortList.Contains(curCalcType);
        }

        public void GetTime(out DateTime start, out DateTime end)
        {
            start = startDateEdit.DateTime;
            end = endDateEdit.DateTime;
        }
        public void SetTime(DateTime start, DateTime end)
        {
            startDateEdit.DateTime = start;
            endDateEdit.DateTime = end;
        }

        public void SetGroup(string groupName, List<string> stockIds)
        {
            curStockIds.Clear();
            foreach (string item in stockIds)
            {
                curStockIds.Add(item);
            }
            curGroupName = groupName;
            InitGroupInfo();
        }

        public void GetGroup(out string groupName, out List<string> stockIds)
        {
            stockIds = curStockIds;
            groupName = curGroupName;
        }

        private void InitGroupInfo()
        {
            if (curGroupName.Trim().Length != 0)
            {
                groupInfoPanel.Text = curGroupName;
            }
            groupListBox.Items.Clear();
            if (curStockIds.Count == 0)
            {
                groupInfoPanel.Text = "自选：全部股票";
                foreach (DataRow row in Commons.classificationTable.Rows)
                {
                    groupListBox.Items.Add(row["stockid"] + " : " + row["stockname"]);
                }
                return;
            }
            foreach (string id in curStockIds)
            {
                string name;
                try
                {
                    name = Commons.classificationTable.Select("stockid=" + id)[0]["stockname"].ToString();
                }
                catch (Exception)
                {
                    name = "未知名称";
                }
                groupListBox.Items.Add(id + " : " + name);
            }
            
        }

        private void InitSearch()
        {
            calTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            {   // 初始化NDay的Tab
                nDayIndexCombo.Properties.Items.AddRange(Constants.nDayIndexDict.Keys);
                nDayIndexCombo.SelectedIndex = 0;
                nDayTypeCombo.Properties.Items.AddRange(Constants.nDayTypeDict.Keys);
                nDayTypeCombo.SelectedIndex = 0;
                nDayCategoryCombo.SelectedIndex = 0;
            }
            {   // 初始化自定义计算的Tab
                calTypeCombo.Properties.Items.AddRange(Constants.customCalTypeDict.Keys);
                calTypeCombo.SelectedIndex = 0;
                calIndexCombo.Properties.Items.AddRange(Constants.customCalIndexDict.Keys);
                calIndexCombo.SelectedIndex = 0;
            }
            {   // 初始化跨区的Tab
                crossIndexCombo.Properties.Items.AddRange(Constants.crossIndexDict.Keys);
                crossIndexCombo.SelectedIndex = 0;
            }
        }

        private void BindData(DataTable dt, bool merge)
        {
            if (!savedArgs.Keys.Contains("command") || curApiName != savedArgs["command"])
            {
                gridView1.Columns.Clear();
                
            }
            
            InsertColumns(dt);
            if (merge)
            {
                DataTable tmpDt = gridControl1.DataSource as DataTable;
                tmpDt.Merge(dt);
            }
            else
            {
                gridControl1.DataSource = dt;
            }
        }

        private void InsertColumns(DataTable dt)
        {
            if (dt.Columns.Contains("stockid") && !dt.Columns.Contains("stockname"))
            {
                DataColumn c = dt.Columns.Add("stockname");
                c.SetOrdinal(1);
                
                foreach (DataRow row in dt.Rows)
                {
                    DataTable nameTable = Commons.classificationTable;
                    try
                    {
                        row["stockname"] = nameTable.Select("stockid = " + row["stockid"])[0]["stockname"];
                    }
                    catch (Exception)
                    {
                        row["stockname"] = "未知名称";
                    }
                    
                }
            }
        }

        private void RenameColumnHeader()
        {
            foreach (GridColumn column in gridView1.Columns)
            {
                if (Constants.translateDict.Keys.Contains(column.FieldName))
                {
                    column.Caption = Constants.translateDict[column.FieldName].name;
                    if (Constants.translateDict[column.FieldName].format.Trim().Length != 0)
	                {
		                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        if (Constants.translateDict[column.FieldName].format.Equals("#"))
                        {
                            switch (curCalcType)
                            {
                                case "nDayCalTab":
                                    column.Caption = nDayIndexCombo.Text + "|" + nDayTypeCombo.Text + "|" + column.Caption + 
                                                       "(" + Constants.translateDict[savedArgs["sumname"]].unit + ")";
                                    break;
                                case "customCalTab":
                                    column.Caption = calIndexCombo.Text + "|" + calTypeCombo.Text + "|" + column.Caption +
                                                       "(" + Constants.translateDict[savedArgs["optname"]].unit + ")";
                                    break;
                                default:
                                    break;
                            }
                            continue;
                        }
                        column.DisplayFormat.FormatString = Constants.translateDict[column.FieldName].format;
                        column.Caption += "(" + Constants.translateDict[column.FieldName].unit + ")";
	                }
                    
                }
            }
        }

        private Dictionary<string, string> getSearchArgs(string searchName)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            #region 判断时间是否有效
            //*
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

            args["pagesize"] = "1000";
            switch (searchName)
            {
                case "nDayCalTab":
                    switch (nDayCategoryCombo.SelectedIndex)
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
                case "crossTab":
                    curApiName = "listcrossinfo";
                    args["optname"] = Constants.crossIndexDict[crossIndexCombo.Text];
                    args["weight"] = crossWeightEdit.Text;
                    break;
                case "growthBoardTab":
                    curApiName = "listgrowthboard";
                    args["weight"] = growthBoardWeightEdit.Text;
                    break;
                default:
                    curApiName = curCalcType;
                    break;
            }

            args["command"] = curApiName;
            args["starttime"] = startDate;
            args["endtime"] = endDate;
            args["page"] = "1";
            args["response"] = "json";
            return args;
        }

        private void nDayCategoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int min = 1;
            int max = 1;
            switch (nDayCategoryCombo.SelectedIndex)
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> args = getSearchArgs(curCalcType);
            if (args == null)
            {
                return;
            }
            if (DoSearch(args))
            {
                curFilter = "";
                curStatusText = "";
                parentForm.ShowStatusInStatusBar(curStatusText);
            }
        }

        public void DoFilterSearch(string filter)
        {
            Dictionary<string, string> args = getSearchArgs(curCalcType);
            if (args == null)
            {
                return;
            }
            args["filter"] = filter;
            if (DoSearch(args))
            {
                curFilter = filter;
            }
        }

        private bool DoSearch(Dictionary<string, string> args)
        {
            parentForm.ShowWaitForm();
            bool ret = true;
            do
            {
                int tmpTotalPage;
                DataSet ds;
                ret = JSONHandler.CallApi(args, out tmpTotalPage, out ds);
                if (ret)
                {
                    DataTable dt = ds.Tables[0].Copy();
                    dt.TableName = curApiName;
                    if (dt.Rows.Count == 0)
                    {
                        ret = false;
                        break;
                    }
                    page = Convert.ToInt32(args["page"]);
                    //int pageSize = Convert.ToInt32(args["pagesize"]);
                    //page += (pageSize / 1000 - 1);
                    totalPage = tmpTotalPage;
                    BindData(dt, page != 1);
                    savedArgs = args;
                    RenameColumnHeader();
                    pageLabel.Text = page + "/" + totalPage;
                }
            } while (false);

            parentForm.CloseWaitForm();
            if (!ret)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("查询结果为空");
                return false;
            }
            return true;
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText =
                    Convert.ToString(Convert.ToInt32(e.RowHandle.ToString()) + 1);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.XtraGrid.Menu.GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //Erasing the default menu items 
                //menu.Items.Clear();
                menu.Items.RemoveAt(0);
                menu.Items.RemoveAt(0);
                if (menu.Column != null)
                {
                    //Adding new items 

                    menu.Items.Add(CreateCheckItem("Fixed None", menu.Column, FixedStyle.None,
                      null));
                    menu.Items[menu.Items.Count - 1].BeginGroup = true;
                    menu.Items.Add(CreateCheckItem("Fixed Left", menu.Column, FixedStyle.Left,
                      null));
                    menu.Items.Add(CreateCheckItem("Fixed Right", menu.Column, FixedStyle.Right,
                      null));
                }
            }
            else if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                e.Menu.Items.Clear();
                AddRightMenu(e.Menu, "导出本页", true);
                AddRightMenu(e.Menu, "打印本页", false);
                if (!Constants.customSortList.Contains(curCalcType))
                {
                    AddRightMenu(e.Menu, "拼接选中行", true);
                    AddRightMenu(e.Menu, "拼接本页", false);
                }
                
                AddRightMenu(e.Menu, "新建分组", true);
            }
        }

        private void AddRightMenu(GridViewMenu menu, string name, bool beginGroup)
        {
            DXMenuItem item = new DXMenuItem();
            item.BeginGroup = beginGroup;
            item.Click += new EventHandler(this.rightKeyClick);
            item.Caption = name;
            menu.Items.Add(item);
        }

        private void rightKeyClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            switch (item.Caption)
            {
                case "导出本页":
                    parentForm.Export(gridControl1);
                    break;
                case "打印本页":
                    parentForm.Print(gridControl1);
                    break;
                case "拼接选中行":
                    parentForm.Combine(gridControl1, true);
                    break;
                case "拼接本页":
                    parentForm.Combine(gridControl1, false);
                    break;
                case "新建分组":
                    int []rowIds = gridView1.GetSelectedRows();
                    List<string> selectedIds = new List<string>();
                    foreach (int rowId in rowIds)
                    {
                        DataRow row = gridView1.GetDataRow(rowId);
                        selectedIds.Add(row["stockid"].ToString());
                    }
                    string groupName = GroupDialog.NewGroupFromGrid(selectedIds);
                    parentForm.AddToGroupMenu(groupName);
                    break;
                default:
                    break;
            }
        }

        //Create a menu item 
        DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, FixedStyle style, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style,
              image, new EventHandler(OnFixedClick));
            item.Tag = new MenuInfo(column, style);

            return item;
        }

        //Menu item click handler 
        void OnFixedClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuInfo info = item.Tag as MenuInfo;
            if (info == null) return;
            info.Column.Fixed = info.Style;
            if (info.Style != FixedStyle.None)
            {
                info.Column.AppearanceCell.BackColor = Color.LightBlue;
            }
            else
            {
                info.Column.AppearanceCell.BackColor = Color.Empty;
            }

        }

        //The class that stores menu specific information 
        class MenuInfo
        {
            public MenuInfo(GridColumn column, FixedStyle style)
            {
                this.Column = column;
                this.Style = style;
            }
            public FixedStyle Style;
            public GridColumn Column;
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1)
                return;

            GridView view = sender as GridView;
            if (view.State != GridState.ColumnDown)
                return;

            if (e.Button == MouseButtons.Left) //clicking left button shows tooltips according to different cells
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                if (hitInfo.InColumn)
                {
                    if (hitInfo.Column.FieldName.Equals("stockname"))
                    {
                        return;
                    }
                    if (Constants.customSortList.Contains(curCalcType))
                    {
                        Dictionary<string, string> args = getSearchArgs(curCalcType);
                        if (args == null)
                        {
                            return;
                        }
                        args["sortname"] = hitInfo.Column.FieldName;
                        if (hitInfo.Column.SortOrder == ColumnSortOrder.Ascending)
                            args["asc"] = "false";
                        else
                            args["asc"] = "true";
                        if (curFilter.Trim().Length != 0)
                        {
                            args["filter"] = curFilter;
                        }
                        DoSearch(args);
                    }

                    if (hitInfo.Column.SortOrder == ColumnSortOrder.Ascending)
                    {
                        hitInfo.Column.SortOrder = ColumnSortOrder.Descending;
                    }
                    else
                    {
                        view.ClearSorting();
                        hitInfo.Column.SortOrder = ColumnSortOrder.Ascending;
                    }
                }
            }
        }

        private void showMoreX5Button_Click(object sender, EventArgs e)
        {
            //ShowMore(5000);
        }

        private void showMoreButton_Click(object sender, EventArgs e)
        {
            ShowMore(1000);
        }

        private void ShowMore(int pagesize)
        {
            if (savedArgs.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("当前无查询");
                return;
            }
            if (page >= totalPage)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("已经是尾页");
                return;
            }
            Dictionary<string, string> args = getSearchArgs(curCalcType);
            if (args == null)
            {
                return;
            }
            args["page"] = "" + (page + 1);
            args["pagesize"] = "" + pagesize;
            DoSearch(args);
        }

        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = 0;
            decimal total = 0;
            decimal avg = 0;
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            foreach (GridCell cell in gridView1.GetSelectedCells())
            {
                if (cell.Column.ColumnType == total.GetType())
                {
                    try
                    {
                        decimal value = Convert.ToDecimal(gridView1.GetRowCellValue(cell.RowHandle, cell.Column));
                        total += value;
                        max = value > max ? value : max;
                        min = value < min ? value : min;
                        count++;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            if (count == 0 )
            {
                parentForm.ShowResultInStatusBar("");
                return;
            }
            avg = count != 0 ? total / count : 0;
            parentForm.ShowResultInStatusBar(string.Format("个数：{0}    均值：{1:f4}    最大：{2:f4}    最小：{3:f4}    求和：{4:f4}                       ",
                                            count, avg, max, min, total));
        }
        
        public GridControl GetGridControl()
        {
            return gridControl1;
        }
    }
}
