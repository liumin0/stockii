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
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;

namespace Stockii.UI
{
    public partial class RibbonManage : DevExpress.XtraEditors.XtraForm
    {
        private MainForm parentForm = null;
        public RibbonManage(MainForm form)
        {
            InitializeComponent();
            parentForm = form;
            RefreshShotcutListBox();
            RefreshUnuseListBox();
        }

        private void RefreshUnuseListBox()
        {
            unuseList.Items.Clear();
            foreach (BarItem item in Commons.unUseRibbonItems)
            {
                unuseList.Items.Add(item.Caption);
            }
        }

        private void RefreshShotcutListBox()
        {
            shotcutList.Items.Clear();
            foreach (BarItemLink link in parentForm.ribbonPageGroup5.ItemLinks)
	        {
                shotcutList.Items.Add(link.Caption);
	        }
            
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int index = shotcutList.SelectedIndex;
            if (index <= 0)
            {
                return;
            }
            BarItemLink link = parentForm.ribbonPageGroup5.ItemLinks[index];
            BarItem item = link.Item;
            parentForm.ribbonPageGroup5.ItemLinks.RemoveAt(index);
            parentForm.ribbonPageGroup5.ItemLinks.Insert(index - 1, item);
            RefreshShotcutListBox();
            shotcutList.SelectedIndex = index - 1;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int index = shotcutList.SelectedIndex;
            if (index >= parentForm.ribbonPageGroup5.ItemLinks.Count - 1)
            {
                return;
            }
            BarItemLink link = parentForm.ribbonPageGroup5.ItemLinks[index];
            BarItem item = link.Item;
            parentForm.ribbonPageGroup5.ItemLinks.RemoveAt(index);
            parentForm.ribbonPageGroup5.ItemLinks.Insert(index + 1, item);
            RefreshShotcutListBox();
            shotcutList.SelectedIndex = index + 1;
        }

        private void shotcutList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = shotcutList.SelectedIndex;
            if (index <= 0)
            {
                upButton.Enabled = false;
            }
            else
            {
                upButton.Enabled = true;
            }
            if (index >= parentForm.ribbonPageGroup5.ItemLinks.Count - 1 || index < 0)
            {
                downButton.Enabled = false;
            }
            else
            {
                downButton.Enabled = true;
            }
            if (index < 0)
            {
                rightButton.Enabled = false;
            }
            else
            {
                rightButton.Enabled = true;
            }
            
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            int index = shotcutList.SelectedIndex;
            BarItemLink link = parentForm.ribbonPageGroup5.ItemLinks[index];
            BarItem item = link.Item;
            Commons.unUseRibbonItems.Add(item);
            parentForm.ribbonPageGroup5.ItemLinks.RemoveAt(index);
            RefreshShotcutListBox();
            RefreshUnuseListBox();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            int index = unuseList.SelectedIndex;
            
            BarItem item = Commons.unUseRibbonItems[index];
            parentForm.ribbonPageGroup5.ItemLinks.Add(item);
            Commons.unUseRibbonItems.Remove(item);
            RefreshShotcutListBox();
            RefreshUnuseListBox();
        }

        private void unuseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unuseList.Items.Count > 0)
            {
                leftButton.Enabled = true;
            }
            else
            {
                leftButton.Enabled = false;
            }
        }
    }
}