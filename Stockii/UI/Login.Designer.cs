namespace Stockii.UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.userNameEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.passwdEdit = new DevExpress.XtraEditors.TextEdit();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveUserName = new DevExpress.XtraEditors.CheckEdit();
            this.savePasswd = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwdEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePasswd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Stockii.UI.Properties.Resources.lauching;
            this.pictureEdit1.Location = new System.Drawing.Point(-3, -5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit1.Properties.AllowScrollViaMouseDrag = false;
            this.pictureEdit1.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(407, 183);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseDown);
            this.pictureEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseMove);
            this.pictureEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseUp);
            // 
            // userNameEdit
            // 
            this.userNameEdit.Location = new System.Drawing.Point(105, 184);
            this.userNameEdit.Name = "userNameEdit";
            this.userNameEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.userNameEdit.Properties.NullValuePrompt = "用户名";
            this.userNameEdit.Properties.NullValuePromptShowForEmptyValue = true;
            this.userNameEdit.Size = new System.Drawing.Size(190, 20);
            this.userNameEdit.TabIndex = 1;
            this.userNameEdit.SelectedIndexChanged += new System.EventHandler(this.userNameEdit_SelectedIndexChanged);
            this.userNameEdit.EditValueChanged += new System.EventHandler(this.userNameEdit_EditValueChanged);
            // 
            // passwdEdit
            // 
            this.passwdEdit.Location = new System.Drawing.Point(105, 210);
            this.passwdEdit.Name = "passwdEdit";
            this.passwdEdit.Properties.NullValuePrompt = "密码";
            this.passwdEdit.Properties.NullValuePromptShowForEmptyValue = true;
            this.passwdEdit.Properties.UseSystemPasswordChar = true;
            this.passwdEdit.Size = new System.Drawing.Size(190, 20);
            this.passwdEdit.TabIndex = 2;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(105, 268);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(190, 28);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "登陆";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // rememberUserName
            // 
            this.saveUserName.EditValue = true;
            this.saveUserName.Location = new System.Drawing.Point(105, 237);
            this.saveUserName.Name = "rememberUserName";
            this.saveUserName.Properties.Caption = "记住账号";
            this.saveUserName.Size = new System.Drawing.Size(75, 19);
            this.saveUserName.TabIndex = 4;
            this.saveUserName.CheckedChanged += new System.EventHandler(this.rememberUserName_CheckedChanged);
            // 
            // rememberPasswd
            // 
            this.savePasswd.Location = new System.Drawing.Point(220, 237);
            this.savePasswd.Name = "rememberPasswd";
            this.savePasswd.Properties.Caption = "记住密码";
            this.savePasswd.Size = new System.Drawing.Size(75, 19);
            this.savePasswd.TabIndex = 4;
            this.savePasswd.CheckedChanged += new System.EventHandler(this.rememberPasswd_CheckedChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 306);
            this.Controls.Add(this.savePasswd);
            this.Controls.Add(this.saveUserName);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwdEdit);
            this.Controls.Add(this.userNameEdit);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwdEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePasswd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit userNameEdit;
        private DevExpress.XtraEditors.TextEdit passwdEdit;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.CheckEdit saveUserName;
        private DevExpress.XtraEditors.CheckEdit savePasswd;


    }
}