using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockii
{
    public class Commons
    {
        public static List<DateTime> tradeDates = new List<DateTime>();
        public static DataSet dataSet = new DataSet();
        
        /// <summary>
        /// 初始化所有全局变量
        /// </summary>
        /// <returns>初始化是否成功</returns>
        public static bool InitCommons()
        {
            if (!InitTradeDate())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("初始化交易日信息失败");
                return false;
            }
            if (!InitClassification())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("初始地域行业信息失败");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化地域行业信息
        /// </summary>
        /// <returns>初始化是否成功</returns>
        private static bool InitClassification()
        {
            DataSet ds;
            bool ret = WebService.GetClassfication(out ds);
            if (ret)
            {
                ds.Tables[0].TableName = "classification_info";
                dataSet.Tables.Add(ds.Tables[0].Copy());
            }
            
            return ret;
        }

        /// <summary>
        /// 初始化交易日信息
        /// </summary>
        /// <returns>初始化是否成功</returns>
        private static bool InitTradeDate()
        {
            DataSet ds;
            bool ret = WebService.GetTradeDate(out ds);
            if (ret)
            {
                try
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        String dateStr = (String)row["listdate"];
                        DateTimeFormatInfo dtfi = new CultureInfo("zh-CN", false).DateTimeFormat;
                        DateTime dateTime = DateTime.ParseExact(dateStr, "yyyy-MM-ddThh:mm:sszzz", dtfi, DateTimeStyles.None);
                        tradeDates.Add(dateTime);
                    }
                }
                catch (Exception)
                {
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// 判断是不是交易日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsTradeDay(DateTime date)
        {
            DateTime riqi = Convert.ToDateTime(date.ToShortDateString() + "T00:00:00" + date.ToString("zzz"));
            if (tradeDates.Contains(riqi))
            {
                return true;
            }
            return false;
        }
    }
}
