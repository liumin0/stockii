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

        //private CustomBool keepXxx = CustomBool.否;
        //[DisplayName("test"), CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持分组与上一页面一致")]
        //public CustomBool KeepXxx
        //{
        //    get { return keepXxx; }
        //    set { keepXxx = value; }
        //}
    }
}
