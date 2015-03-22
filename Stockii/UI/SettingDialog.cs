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
using System.IO;

namespace Stockii.UI
{
    public partial class SettingDialog : DevExpress.XtraEditors.XtraForm
    {
        public SettingDialog()
        {
            InitializeComponent();
            propertyGridControl1.SelectedObject = Commons.property;
        }

        private void SettingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.SaveProperty();
            
        }
    }
}