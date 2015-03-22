namespace Stockii.UI
{
    partial class RibbonManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonManage));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.upButton = new DevExpress.XtraEditors.SimpleButton();
            this.leftButton = new DevExpress.XtraEditors.SimpleButton();
            this.shotcutList = new DevExpress.XtraEditors.ListBoxControl();
            this.unuseList = new DevExpress.XtraEditors.ListBoxControl();
            this.rightButton = new DevExpress.XtraEditors.SimpleButton();
            this.downButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.shotcutList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unuseList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "当前页面快捷键：";
            // 
            // upButton
            // 
            this.upButton.Enabled = false;
            this.upButton.Image = ((System.Drawing.Image)(resources.GetObject("upButton.Image")));
            this.upButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.upButton.Location = new System.Drawing.Point(225, 47);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(32, 32);
            this.upButton.TabIndex = 2;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Enabled = false;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.leftButton.Location = new System.Drawing.Point(225, 235);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(32, 32);
            this.leftButton.TabIndex = 2;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // shotcutList
            // 
            this.shotcutList.Location = new System.Drawing.Point(12, 33);
            this.shotcutList.Name = "shotcutList";
            this.shotcutList.Size = new System.Drawing.Size(207, 270);
            this.shotcutList.TabIndex = 3;
            this.shotcutList.SelectedIndexChanged += new System.EventHandler(this.shotcutList_SelectedIndexChanged);
            // 
            // unuseList
            // 
            this.unuseList.Location = new System.Drawing.Point(263, 33);
            this.unuseList.Name = "unuseList";
            this.unuseList.Size = new System.Drawing.Size(207, 270);
            this.unuseList.TabIndex = 3;
            this.unuseList.SelectedIndexChanged += new System.EventHandler(this.unuseList_SelectedIndexChanged);
            // 
            // rightButton
            // 
            this.rightButton.Enabled = false;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.rightButton.Location = new System.Drawing.Point(225, 197);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(32, 32);
            this.rightButton.TabIndex = 2;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // downButton
            // 
            this.downButton.Enabled = false;
            this.downButton.Image = ((System.Drawing.Image)(resources.GetObject("downButton.Image")));
            this.downButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.downButton.Location = new System.Drawing.Point(225, 85);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(32, 32);
            this.downButton.TabIndex = 2;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(263, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "可以使用的功能：";
            // 
            // RibbonManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 311);
            this.Controls.Add(this.unuseList);
            this.Controls.Add(this.shotcutList);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RibbonManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RibbionManage";
            ((System.ComponentModel.ISupportInitialize)(this.shotcutList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unuseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton upButton;
        private DevExpress.XtraEditors.SimpleButton leftButton;
        private DevExpress.XtraEditors.ListBoxControl shotcutList;
        private DevExpress.XtraEditors.ListBoxControl unuseList;
        private DevExpress.XtraEditors.SimpleButton rightButton;
        private DevExpress.XtraEditors.SimpleButton downButton;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}