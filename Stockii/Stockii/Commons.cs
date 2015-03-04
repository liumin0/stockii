using DevExpress.XtraBars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stockii
{
    public class Commons
    {
        public static List<DateTime> tradeDates = new List<DateTime>();
        public static DataSet dataSet = new DataSet();
        public static SerializableDictionary<String, List<string>> groupDict = new SerializableDictionary<string, List<string>>();
        public static Dictionary<String, List<string>> areaDict = new Dictionary<string, List<string>>();
        public static Dictionary<String, List<string>> industryDict = new Dictionary<string, List<string>>();
        public static List<BarCheckItem> menuItems = new List<BarCheckItem>();
        /// <summary>
        /// 初始化所有全局变量
        /// </summary>
        /// <returns>初始化是否成功</returns>
        public static bool InitCommons()
        {
            //if (!InitTradeDate())
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("初始化交易日信息失败");
            //    return false;
            //}
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
                try
                {
                    DataTable dt = ds.Tables[0];
                    dt.TableName = Constants.classificationTableName;
                    dataSet.Tables.Add(dt.Copy());
                    foreach (DataRow row in dt.Rows)
                    {
                        string areaName = row["areaname"].ToString().Trim();
                        string industryName = row["industryname"].ToString().Trim();
                        
                        if (!areaDict.Keys.Contains(areaName))
                        {
                            areaDict[areaName] = new List<string>();
                            
                        }
                        if (!industryDict.Keys.Contains(industryName))
                        {
                            industryDict[industryName] = new List<string>();

                        }
                        areaDict[areaName].Add(row["stockid"].ToString().Trim());
                        industryDict[industryName].Add(row["stockid"].ToString().Trim());
                    }
                }
                catch (Exception e)
                {
                    ret = false;
                }
                
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

        /// <summary>
        /// 保存分组信息
        /// </summary>
        public static void SaveGroup()
        {
            using (FileStream fileStream = new FileStream(Constants.groupConfigPath, FileMode.Create))
            {
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, List<string>>));
                xmlFormatter.Serialize(fileStream, groupDict);
            }
        }

        public static void DeleteGroup(string name)
        {
            groupDict.Remove(name);
            SaveGroup();
        }

        public static void EditGroup(string name, List<string> list)
        {
            groupDict[name] = list;
            SaveGroup();
        }

        
    }
}
