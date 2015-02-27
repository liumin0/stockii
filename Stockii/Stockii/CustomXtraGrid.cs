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
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.Menu;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Stockii
{
    public partial class CustomXtraGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public CustomXtraGrid()
        {
            InitializeComponent();
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
                    
                    //DataTable dt = new DataTable("hello");
                    //int colN = 5;
                    //int rowN = 1000;
                    //for (int i = 1; i < colN; i++)
                    //{
                    //    dt.Columns.Add(String.Format("gridColumn{0}", i), "".GetType());
                    //}
                    //for (int i = 0; i < rowN; i++)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    for (int j = 1; j < colN; j++)
                    //    {
                    //        dr[String.Format("gridColumn{0}", j)] = (j).ToString();
                    //    }
                    //    dt.Rows.Add(dr);
                    //}
                    //gridControl1.DataSource = dt;
                    
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            switch (e.Column.FieldName)
            {
                case "created":
                    e.DisplayText = string.Format("{0:d} ff", e.Value);
                    break;
                case "threesum":
                    e.DisplayText = string.Format("{0:f2} ff", e.Value);
                    break;
                default:
                    break;
            }
            
        }
    }
}
