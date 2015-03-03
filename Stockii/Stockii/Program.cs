using DevExpress.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Stockii
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            //DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2013 Light Gray");
            //Application.Run(new MainForm());
            DataDirectoryHelper.LocalPrefix = "Stockii";
            DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2013");
            DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
            bool exit;
            using (IDisposable singleInstanceApplicationGuard = DataDirectoryHelper.SingleInstanceApplicationGuard("Stockii", out exit))
            {
                if (exit)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("程序已经启动");
                    return;
                } 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
