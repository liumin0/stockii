using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Stockii.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockii
{
    public class GridCommons
    {
        /// <summary>
        /// 给表的每一行添加行号
        /// </summary>
        /// <param name="main"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawRowIndicator(MainForm main, object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText =
                    Convert.ToString(Convert.ToInt32(e.RowHandle.ToString()) + 1);
            }
        }

        /// <summary>
        /// 选中实时计算
        /// </summary>
        /// <param name="main"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SelectionChanged(MainForm main, object sender, SelectionChangedEventArgs e)
        {
            int count = 0;
            decimal total = 0;
            decimal avg = 0;
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            GridView view = sender as GridView;
            foreach (GridCell cell in view.GetSelectedCells())
            {
                if (cell.Column.ColumnType == total.GetType())
                {
                    try
                    {
                        decimal value = Convert.ToDecimal(view.GetRowCellValue(cell.RowHandle, cell.Column));
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
            if (count == 0)
            {
                main.ShowResultInStatusBar("");
                return;
            }
            avg = count != 0 ? total / count : 0;
            main.ShowResultInStatusBar(string.Format("个数：{0}    均值：{1:f4}    最大：{2:f4}    最小：{3:f4}    求和：{4:f4}                       ",
                                            count, avg, max, min, total));
        }

        /// <summary>
        /// 给列表头添加锁定选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void AddFixMenu(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
        public static DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, FixedStyle style, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style,
              image, new EventHandler(OnFixedClick));
            item.Tag = new MenuInfo(column, style);

            return item;
        }

        //Menu item click handler 
        public static void OnFixedClick(object sender, EventArgs e)
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
    }
}
