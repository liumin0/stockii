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

namespace Stockii.UI
{
    public partial class SaveAction : DevExpress.XtraEditors.XtraForm
    {
        public SaveAction()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameEdit.Text.Trim();
            if (name.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("名称不能为空");
                return;
            }
            if (Commons.combineDict.Keys.Contains(name))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("该操作名称已存在");
                return;
            }
            Commons.SaveCombine(name);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}