using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockii
{
    [Serializable]
    public class Property
    {
        public enum CustomBool{
            是,
            否
        }
        private CustomBool keepTime = CustomBool.是;
        private CustomBool keepGroup = CustomBool.是;
        private int lineLimit = 2000;
        private bool saveUserName = true;
        private bool savePasswd = true;

        [DisplayName("保持时间"),CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持时间与上一页面一致")]
        public CustomBool KeepTime
        {
            get { return keepTime; }
            set { keepTime = value; }
        }

        [DisplayName("保持分组"), CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持分组与上一页面一致")]
        public CustomBool KeepGroup
        {
            get { return keepGroup; }
            set { keepGroup = value; }
        }

        [DisplayName("每页行数"), CategoryAttribute("页面"), DescriptionAttribute("对于数据量很多的表限定显示的行数")]
        public int LineLimit
        {
            get { return lineLimit; }
            set { lineLimit = value; }
        }

        [Browsable(false)]
        public bool SaveUserName
        {
            get { return saveUserName; }
            set { saveUserName = value; }
        }

        [Browsable(false)]
        public bool SavePasswd
        {
            get { return savePasswd; }
            set { savePasswd = value; }
        }
        //private CustomBool keepXxx = CustomBool.否;
        //[DisplayName("test"), CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持分组与上一页面一致")]
        //public CustomBool KeepXxx
        //{
        //    get { return keepXxx; }
        //    set { keepXxx = value; }
        //}
    }
}
