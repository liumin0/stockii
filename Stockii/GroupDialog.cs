﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Stockii
{
    public partial class GroupDialog : DevExpress.XtraEditors.XtraForm
    {
        private static string groupName = null;
        private static List<string> selectedIds = new List<string>();
        private DataTable selectTable = new DataTable();
        private DataTable totalTable = new DataTable();
        private static bool isEdit = false;
        public GroupDialog()
        {
            InitializeComponent();
            InitTotalGrid();
            InitSelectGrid();
            InitAreaCombo();
            InitIndustryCombo();
            industryCombo.CheckAll();
            areaCombo.CheckAll();
            deleteButton.Enabled = false;
            if (!isEdit)
            {
                groupNameCombo.Properties.Buttons[0].Visible = false;
                deleteGroupButton.Visible = false;
                groupNameCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
            else
            {
                groupNameCombo.Properties.Items.AddRange(Commons.groupDict.Keys);
                groupNameCombo.SelectedIndex = 0;
                groupNameCombo.Properties.Buttons[0].Visible = true;
                deleteGroupButton.Visible = true;
                groupNameCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
        }

        private void InitIndustryCombo()
        {
            foreach (string name in Commons.industryDict.Keys)
            {
                if (name.Trim().Length != 0)
                {
                    industryCombo.Properties.Items.Add(name);
                }
                
            }
        }

        private void InitAreaCombo()
        {
            foreach (string name in Commons.areaDict.Keys)
            {
                if (name.Trim().Length != 0)
                {
                    areaCombo.Properties.Items.Add(name);
                }
            }
        }

        private void InitSelectGrid()
        {
            selectTable.Columns.Add("stockid");
            selectTable.Columns.Add("stockname");
            selectStockGrid.DataSource = selectTable;
        }

        private void InitTotalGrid()
        {
            totalTable.Columns.Add("stockid");
            totalTable.Columns.Add("stockname");
            InitTableFromTable(totalTable,Commons.classificationTable, "");
            totalStockGrid.DataSource = totalTable;
        }

        private void InitTableFromTable(DataTable table, DataTable fromTable, string filter)
        {
            foreach (DataRow row in fromTable.Select(filter))
            {
                DataRow dr = table.NewRow();
                dr[0] = row["stockid"].ToString();
                dr[1] = row["stockname"].ToString();
                table.Rows.Add(dr);
            }
        }

        public static string NewGroup()
        {
            groupName = null;
            selectedIds = new List<string>();
            isEdit = false;
            GroupDialog groupDialog = new GroupDialog();
            groupDialog.ShowDialog();
            if (groupName != null)
            {
                Commons.EditGroup(groupName, selectedIds);
            }
            return groupName;
        }

        public static string NewGroupFromGrid(List<string> ids)
        {
            groupName = null;
            selectedIds = new List<string>();
            isEdit = false;
            GroupDialog groupDialog = new GroupDialog();
            groupDialog.AddStockIds(ids);
            groupDialog.ShowDialog();
            if (groupName != null)
            {
                Commons.EditGroup(groupName, selectedIds);
            }
            return groupName;
        }

        public static void EditStock()
        {
            groupName = null;
            selectedIds = new List<string>();
            isEdit = true;
            GroupDialog groupDialog = new GroupDialog();
            groupDialog.ShowDialog();
            if (groupName != null)
            {
                Commons.EditGroup(groupName, selectedIds);
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

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.IndicatorWidth = 25 + 7 * view.RowCount.ToString().Length;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks > 1)
            {
                AddRow(e.RowHandle);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (groupNameCombo.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("分组名称不能为空");
                return;
            }
            if (selectedIds.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("选择的股票列表不能为空");
                return;
            }
            groupName = groupNameCombo.Text;
            if (!isEdit)
            {
                if (Commons.groupDict.Keys.Contains(groupName))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("分组名称已经存在");
                    return;
                }
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRow(int rowHandle)
        {
            if (selectedIds.Contains(totalStockView.GetDataRow(rowHandle)[0].ToString()))
            {
                return;
            }
            DataRow dr = selectTable.NewRow();
            dr[0] = totalStockView.GetDataRow(rowHandle)[0];
            dr[1] = totalStockView.GetDataRow(rowHandle)[1];
            selectTable.Rows.Add(dr);
            selectedIds.Add(dr[0].ToString());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            selectStockView.BeginDataUpdate();
            foreach (int rowHandle in totalStockView.GetSelectedRows())
            {
                AddRow(rowHandle);
            }
            selectStockView.EndDataUpdate();
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            selectStockView.BeginDataUpdate();
            for (int i = 0; i < totalStockView.RowCount; i++)
            {
                AddRow(i);
            }
            selectStockView.EndDataUpdate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            selectTable.Clear();
            selectedIds.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            List<DataRow> rmRows = new List<DataRow>();
            foreach (int rowHandle in selectStockView.GetSelectedRows())
            {
                if (!selectedIds.Contains(selectStockView.GetDataRow(rowHandle)[0].ToString()))
                {
                    continue;
                }
                rmRows.Add(selectStockView.GetDataRow(rowHandle));
               
            }
            selectStockView.BeginDataUpdate();
            foreach (DataRow row in rmRows)
            {
                selectedIds.Remove(row[0].ToString());
                selectTable.Rows.Remove(row);
            }     
            selectStockView.EndDataUpdate();
        }

        private void selectStockView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (selectStockView.GetSelectedRows().Length > 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
            }
        }

        private void deleteGroupButton_Click(object sender, EventArgs e)
        {
            string groupName = groupNameCombo.Text;
            int index = groupNameCombo.SelectedIndex;
            groupNameCombo.Properties.Items.RemoveAt(index);
            Commons.DeleteGroup(groupName);
            groupNameCombo.SelectedIndex = 0;
        }

        private void groupNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> ids = Commons.groupDict[groupNameCombo.Text];
            AddStockIds(ids);
        }

        private void AddStockIds(List<string> stockIds)
        {
            selectStockView.BeginDataUpdate();
            clearButton.PerformClick();

            InitTableFromTable(selectTable, Commons.classificationTable, "stockid in ('" + string.Join("','", stockIds.ToArray()) + "')");
            selectedIds = stockIds;
            selectStockView.EndDataUpdate();
        }

        private void areaCombo_EditValueChanged(object sender, EventArgs e)
        {
            string selectedAreas = areaCombo.Properties.GetCheckedItems() as string;
            string[] areaNames = selectedAreas.Split(',');
            string areaFilter = "'" + selectedAreas.Replace(", ", "','") + "'";
            string selectedIndustries = industryCombo.Properties.GetCheckedItems() as string;
            string[] industryNames = selectedIndustries.Split(',');
            string industryFilter = "'" + selectedIndustries.Replace(", ", "','") + "'";
            string filter = "";
            totalStockView.BeginDataUpdate();
            totalTable.Clear();
            if (areaNames.Length != areaCombo.Properties.Items.Count)
            {
                filter = "areaname in (" + areaFilter + ")";

            }
            if (industryNames.Length != industryCombo.Properties.Items.Count)
            {
                if (filter.Trim().Length != 0)
                {
                    filter += " and ";
                }
                filter += "industryname in (" + industryFilter + ")";
            }
            
            InitTableFromTable(totalTable, Commons.classificationTable, filter);
            totalStockView.EndDataUpdate();
        }
    }
}