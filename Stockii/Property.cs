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
        private bool keepTime = true;
        private bool keepGroup = true;

        [DisplayName("保持时间"),CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持时间与上一页面一致")]
        public bool KeepTime
        {
            get { return keepTime; }
            set { keepTime = value; }
        }

        [DisplayName("保持分组"), CategoryAttribute("页面"), DescriptionAttribute("新建页面时保持分组与上一页面一致")]
        public bool KeepGroup
        {
            get { return keepGroup; }
            set { keepGroup = value; }
        }
    }
}
