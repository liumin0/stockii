using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace Stockii
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
            
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x02, 0);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userNameEdit.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("用户名不能为空");
                return;
            }
            if (passwdEdit.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("密码不能为空");
                return;
            }
            loginButton.Text = "登录中...";
            SetEnable(false);
            if (WebService.Login(userNameEdit.Text, passwdEdit.Text))
            {
                this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
                this.Visible = false;
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("用户名密码错误");
            }
            loginButton.Text = "登录";
            SetEnable(true);
            
        }

        private void SetEnable(bool enable)
        {
            userNameEdit.Enabled = enable;
            passwdEdit.Enabled = enable;
            rememberUserName.Enabled = enable;
            rememberPasswd.Enabled = enable;
            loginButton.Enabled = enable;
        }
    }
}