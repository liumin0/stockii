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

namespace Stockii
{
    public partial class CustomPage : DevExpress.XtraEditors.XtraUserControl
    {
        private MainForm parentForm;
        private Dictionary<string, string> savedArgs;
        private List<string> curStockIds = new List<string>();
        private string curCalcTYpe = "";
        private string curApiName = "";
        private string curGroupName = "";
        private int page = 1;
        private int totalPage = 1;
        public CustomPage(MainForm mainForm, string calcType)
        {
            InitializeComponent();
            parentForm = mainForm;
            foreach (XtraTabPage page in calTabControl.TabPages)
            {
                if (page.Name.Equals(calcType))
                {
                    calTabControl.SelectedTabPage = page;
                    break;
                }
            }
            curCalcTYpe = calcType;
            InitSearch();
        }

        public void InitPage(string groupName, List<string> stockIds)
        {
            curStockIds.Clear();
            foreach (string item in stockIds)
            {
                curStockIds.Add(item);
            }
            curGroupName = groupName;
            InitGroupInfo();
            
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
            calTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
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

        private void BindData(DataTable dt)
        {
            gridView1.Columns.Clear();
            gridControl1.DataSource = dt;
            RenameColumnHeader();
        }

        private void RenameColumnHeader()
        {
            foreach (GridColumn column in gridView1.Columns)
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> args = getSearchArgs(curCalcTYpe);
            if (args == null)
            {
                return;
            }
            
            parentForm.ShowWaitForm();
            int tmpTotalPage;
            DataSet ds;
            if (JSONHandler.CallApi(args, out tmpTotalPage, out ds))
            {
                savedArgs = args;
                DataTable dt = ds.Tables[0].Copy();
                dt.TableName = curApiName;
                page = 1;
                totalPage = tmpTotalPage;
                BindData(dt);

                pageLabel.Text = page + "/" + totalPage;
            }
            
            parentForm.CloseWaitForm();
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
                    Console.WriteLine("clicked2: {0}", hitInfo.Column.FieldName);
                    //((DevExpress.Utils.DXMouseEventArgs)e).Handled = true;
                    //this.BeginInvoke(new MethodInvoker(view.LayoutChanged));

                    // TODO


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
    }
}
