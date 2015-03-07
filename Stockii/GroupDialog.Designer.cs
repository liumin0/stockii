namespace Stockii
{
    partial class GroupDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupNameCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.deleteGroupButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.areaCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.industryCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.totalStockGrid = new DevExpress.XtraGrid.GridControl();
            this.totalStockView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.addAllButton = new DevExpress.XtraEditors.SimpleButton();
            this.clearButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteButton = new DevExpress.XtraEditors.SimpleButton();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.selectStockGrid = new DevExpress.XtraGrid.GridControl();
            this.selectStockView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupNameCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.industryCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalStockGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalStockView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectStockGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectStockView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "组名：";
            // 
            // groupNameCombo
            // 
            this.groupNameCombo.Location = new System.Drawing.Point(54, 12);
            this.groupNameCombo.Name = "groupNameCombo";
            this.groupNameCombo.Properties.AutoComplete = false;
            this.groupNameCombo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupNameCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.groupNameCombo.Size = new System.Drawing.Size(158, 22);
            this.groupNameCombo.TabIndex = 1;
            this.groupNameCombo.SelectedIndexChanged += new System.EventHandler(this.groupNameCombo_SelectedIndexChanged);
            // 
            // deleteGroupButton
            // 
            this.deleteGroupButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.deleteGroupButton.Location = new System.Drawing.Point(218, 11);
            this.deleteGroupButton.Name = "deleteGroupButton";
            this.deleteGroupButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGroupButton.TabIndex = 2;
            this.deleteGroupButton.Text = "删除分组";
            this.deleteGroupButton.Click += new System.EventHandler(this.deleteGroupButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(319, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "地区：";
            // 
            // areaCombo
            // 
            this.areaCombo.Location = new System.Drawing.Point(361, 13);
            this.areaCombo.Name = "areaCombo";
            this.areaCombo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.areaCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.areaCombo.Size = new System.Drawing.Size(82, 22);
            this.areaCombo.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(459, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "行业：";
            // 
            // industryCombo
            // 
            this.industryCombo.Location = new System.Drawing.Point(501, 13);
            this.industryCombo.Name = "industryCombo";
            this.industryCombo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.industryCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.industryCombo.Size = new System.Drawing.Size(138, 22);
            this.industryCombo.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.Controls.Add(this.totalStockGrid);
            this.groupControl1.Controls.Add(this.searchControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 57);
            this.groupControl1.LookAndFeel.SkinName = "Office 2013";
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(266, 324);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "可选列表";
            // 
            // totalStockGrid
            // 
            this.totalStockGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalStockGrid.Location = new System.Drawing.Point(6, 52);
            this.totalStockGrid.MainView = this.totalStockView;
            this.totalStockGrid.Name = "totalStockGrid";
            this.totalStockGrid.Size = new System.Drawing.Size(255, 267);
            this.totalStockGrid.TabIndex = 2;
            this.totalStockGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.totalStockView});
            // 
            // totalStockView
            // 
            this.totalStockView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.totalStockView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.totalStockView.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.totalStockView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.totalStockView.GridControl = this.totalStockGrid;
            this.totalStockView.Name = "totalStockView";
            this.totalStockView.OptionsBehavior.Editable = false;
            this.totalStockView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.totalStockView.OptionsSelection.MultiSelect = true;
            this.totalStockView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.totalStockView.OptionsView.ShowGroupPanel = false;
            this.totalStockView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.totalStockView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.totalStockView.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "代码";
            this.gridColumn1.FieldName = "stockid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "stockname";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl1.Client = this.totalStockGrid;
            this.searchControl1.Location = new System.Drawing.Point(6, 26);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.totalStockGrid;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Properties.NullValuePrompt = "输入查询条件进行查询";
            this.searchControl1.Size = new System.Drawing.Size(255, 20);
            this.searchControl1.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.addButton.Location = new System.Drawing.Point(284, 131);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "添加";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.addAllButton.Location = new System.Drawing.Point(284, 189);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(75, 23);
            this.addAllButton.TabIndex = 2;
            this.addAllButton.Text = "全部添加";
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.clearButton.Location = new System.Drawing.Point(284, 246);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清空";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.deleteButton.Location = new System.Drawing.Point(284, 305);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "删除";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // okButton
            // 
            this.okButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.okButton.Location = new System.Drawing.Point(172, 401);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cancelButton.Location = new System.Drawing.Point(408, 401);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl2.Controls.Add(this.selectStockGrid);
            this.groupControl2.Location = new System.Drawing.Point(365, 57);
            this.groupControl2.LookAndFeel.SkinName = "Office 2013";
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(274, 324);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "已选列表";
            // 
            // selectStockGrid
            // 
            this.selectStockGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectStockGrid.Location = new System.Drawing.Point(5, 25);
            this.selectStockGrid.MainView = this.selectStockView;
            this.selectStockGrid.Name = "selectStockGrid";
            this.selectStockGrid.Size = new System.Drawing.Size(264, 294);
            this.selectStockGrid.TabIndex = 2;
            this.selectStockGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.selectStockView});
            // 
            // selectStockView
            // 
            this.selectStockView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.selectStockView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.selectStockView.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.selectStockView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.selectStockView.GridControl = this.selectStockGrid;
            this.selectStockView.Name = "selectStockView";
            this.selectStockView.OptionsBehavior.Editable = false;
            this.selectStockView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.selectStockView.OptionsSelection.MultiSelect = true;
            this.selectStockView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.selectStockView.OptionsView.ShowGroupPanel = false;
            this.selectStockView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.selectStockView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.selectStockView_SelectionChanged);
            this.selectStockView.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "代码";
            this.gridColumn3.FieldName = "stockid";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "名称";
            this.gridColumn4.FieldName = "stockname";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // GroupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 433);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addAllButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteGroupButton);
            this.Controls.Add(this.industryCombo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.areaCombo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.groupNameCombo);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 471);
            this.MinimumSize = new System.Drawing.Size(672, 471);
            this.Name = "GroupDialog";
            this.Text = "GroupDialog";
            ((System.ComponentModel.ISupportInitialize)(this.groupNameCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.industryCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.totalStockGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalStockView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectStockGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectStockView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit groupNameCombo;
        private DevExpress.XtraEditors.SimpleButton deleteGroupButton;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit areaCombo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit industryCombo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.SimpleButton addAllButton;
        private DevExpress.XtraEditors.SimpleButton clearButton;
        private DevExpress.XtraEditors.SimpleButton deleteButton;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl totalStockGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView totalStockView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl selectStockGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView selectStockView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}