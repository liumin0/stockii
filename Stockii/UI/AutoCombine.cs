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
    public partial class AutoCombine : DevExpress.XtraEditors.XtraForm
    {
        private string actionName = "";
        private MainForm parentForm;
        public AutoCombine(MainForm mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
            deleteActionButton.Enabled = false;
            startButton.Enabled = false;
            InitActionList();
            InitGroup();
        }

        private void InitGroup()
        {
            groupCombo.Properties.Items.Clear();
            groupCombo.Properties.Items.AddRange(Commons.groupDict.Keys);
            groupCombo.SelectedIndex = 0;
        }

        private void InitActionList()
        {
            actionListEdit.Items.Clear();
            actionListEdit.Items.AddRange(Commons.combineDict.Keys.ToArray());
        }

        private void actionListEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionListEdit.SelectedItem == null)
            {
                deleteActionButton.Enabled = false;
                startButton.Enabled = false;
                return;
            }
            deleteActionButton.Enabled = true;
            startButton.Enabled = true;
            actionName = actionListEdit.SelectedItem.ToString().Trim();
            List<Commons.SavedAction> list = Commons.combineDict[actionName];
            int number = list.Count;// 操作里拼接的个数
            countLabel.Text = "拼接个数：" + number;
            combineInfoEdit.Items.Clear();

            foreach (Commons.SavedAction item in list)
            {
                SerializableDictionary<string, string> args = item.args;
                string indexName = "";
                string optName = "";
                switch (args["command"])
                {
                    case "listcrossinfo":
                        indexName = Constants.GetKeyByValue(Constants.crossIndexDict, args["optname"]);
                        combineInfoEdit.Items.Add("跨区：权重（%）－>" + args["weight"] + "||指标－>" + indexName);
                        break;
                    case "liststockdaysdiff":
                        indexName = Constants.GetKeyByValue(Constants.customCalIndexDict, args["optname"]);
                        optName = Constants.GetKeyByValue(Constants.customCalTypeDict, args["opt"]);
                        combineInfoEdit.Items.Add("自定义计算：比较方法－>" + optName + "|| 比较指标－>" + indexName);
                        break;
                    case "listndayssum":
                        indexName = Constants.GetKeyByValue(Constants.customCalIndexDict, args["optname"]);
                        combineInfoEdit.Items.Add("一段时间内的和： 指标－>" + indexName);
                        break;
                    case "listgrowthampdis":
                        indexName = Constants.GetKeyByValue(Constants.customCalIndexDict, args["optname"]);
                        combineInfoEdit.Items.Add("涨幅振幅分段：指标－>" + indexName);
                        break;
                    default:
                        break;
                }
            }
        }

        private void deleteActionButton_Click(object sender, EventArgs e)
        {
            if (Commons.combineDict.Keys.Contains(actionName))
            {
                Commons.combineDict.Remove(actionName);
            }
            actionListEdit.Items.Remove(actionName);
            combineInfoEdit.Items.Clear();
        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            string groupName = GroupDialog.NewGroup();
            if (groupName != null)
	        {
                groupCombo.Properties.Items.Add(groupName);
                parentForm.AddToGroupMenu(groupName);
	        }
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!Commons.ValidateDate(startDateEdit.DateTime, endDateEdit.DateTime) || groupCombo.Text.Trim().Length == 0)
            {
                return;
            }
            if (Commons.combineDict.Keys.Contains(actionName))
            {
                parentForm.DoAutoCombine(groupCombo.Text.Trim(), startDateEdit.DateTime, endDateEdit.DateTime, Commons.combineDict[actionName]);
            }
            this.Close();
        }


    }
}