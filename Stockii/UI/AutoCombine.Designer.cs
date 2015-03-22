namespace Stockii.UI
{
    partial class AutoCombine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCombine));
            this.actionListEdit = new DevExpress.XtraEditors.ListBoxControl();
            this.combineInfoEdit = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.countLabel = new DevExpress.XtraEditors.LabelControl();
            this.deleteActionButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.startDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.endDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.newGroupButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.actionListEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combineInfoEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // actionListEdit
            // 
            this.actionListEdit.Location = new System.Drawing.Point(4, 59);
            this.actionListEdit.Name = "actionListEdit";
            this.actionListEdit.Size = new System.Drawing.Size(211, 186);
            this.actionListEdit.TabIndex = 0;
            this.actionListEdit.SelectedIndexChanged += new System.EventHandler(this.actionListEdit_SelectedIndexChanged);
            // 
            // combineInfoEdit
            // 
            this.combineInfoEdit.HorizontalScrollbar = true;
            this.combineInfoEdit.ItemAutoHeight = true;
            this.combineInfoEdit.Location = new System.Drawing.Point(4, 271);
            this.combineInfoEdit.Name = "combineInfoEdit";
            this.combineInfoEdit.Size = new System.Drawing.Size(383, 187);
            this.combineInfoEdit.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.actionListEdit;
            this.searchControl1.Location = new System.Drawing.Point(4, 33);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.actionListEdit;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Properties.NullValuePrompt = "输入查询条件查询...";
            this.searchControl1.Size = new System.Drawing.Size(209, 20);
            this.searchControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "已存操作列表：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 251);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "拼接详情：";
            // 
            // countLabel
            // 
            this.countLabel.Location = new System.Drawing.Point(250, 13);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(60, 14);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "拼接个数：";
            // 
            // deleteActionButton
            // 
            this.deleteActionButton.Location = new System.Drawing.Point(250, 36);
            this.deleteActionButton.Name = "deleteActionButton";
            this.deleteActionButton.Size = new System.Drawing.Size(100, 23);
            this.deleteActionButton.TabIndex = 4;
            this.deleteActionButton.Text = "删除操作";
            this.deleteActionButton.Click += new System.EventHandler(this.deleteActionButton_Click);
            // 
            // groupCombo
            // 
            this.groupCombo.Location = new System.Drawing.Point(250, 85);
            this.groupCombo.Name = "groupCombo";
            this.groupCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.groupCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.groupCombo.Size = new System.Drawing.Size(100, 20);
            this.groupCombo.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(250, 65);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "分组：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(250, 111);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "开始时间：";
            // 
            // startDateEdit
            // 
            this.startDateEdit.EditValue = new System.DateTime(2015, 3, 18, 18, 23, 25, 0);
            this.startDateEdit.Location = new System.Drawing.Point(250, 131);
            this.startDateEdit.Name = "startDateEdit";
            this.startDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDateEdit.Size = new System.Drawing.Size(100, 20);
            this.startDateEdit.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(250, 157);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "结束时间：";
            // 
            // endDateEdit
            // 
            this.endDateEdit.EditValue = new System.DateTime(2015, 3, 18, 18, 23, 29, 0);
            this.endDateEdit.Location = new System.Drawing.Point(250, 177);
            this.endDateEdit.Name = "endDateEdit";
            this.endDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Size = new System.Drawing.Size(100, 20);
            this.endDateEdit.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(250, 222);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "开始拼接";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // newGroupButton
            // 
            this.newGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("newGroupButton.Image")));
            this.newGroupButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.newGroupButton.Location = new System.Drawing.Point(356, 86);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new System.Drawing.Size(20, 17);
            this.newGroupButton.TabIndex = 4;
            this.newGroupButton.ToolTip = "新建分组";
            this.newGroupButton.Click += new System.EventHandler(this.newGroupButton_Click);
            // 
            // AutoCombine
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 465);
            this.Controls.Add(this.endDateEdit);
            this.Controls.Add(this.startDateEdit);
            this.Controls.Add(this.groupCombo);
            this.Controls.Add(this.newGroupButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.deleteActionButton);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.combineInfoEdit);
            this.Controls.Add(this.actionListEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(409, 503);
            this.MinimumSize = new System.Drawing.Size(409, 503);
            this.Name = "AutoCombine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自动拼接";
            ((System.ComponentModel.ISupportInitialize)(this.actionListEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combineInfoEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl actionListEdit;
        private DevExpress.XtraEditors.ListBoxControl combineInfoEdit;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl countLabel;
        private DevExpress.XtraEditors.SimpleButton deleteActionButton;
        private DevExpress.XtraEditors.ComboBoxEdit groupCombo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit startDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit endDateEdit;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private DevExpress.XtraEditors.SimpleButton newGroupButton;
    }
}