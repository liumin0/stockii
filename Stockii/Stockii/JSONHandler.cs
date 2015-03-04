using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Net;
using System.Globalization;
using System.Collections;//在C#中使用ArrayList必须引用Collections类

namespace Stockii
{
    /// <summary>
    /// JSON处理类
    /// </summary>
    static class JSONHandler
    {
        public static string commonURL = "http://stockii-gf.oicp.net/client/api";
        //public static string localURL = "http://192.168.1.220:8080/client/api";
        public static string localURL = "http://www.stockii.com:8090/client/api"; 

        /// <summary>
        /// 将JSON解析成DataSet只限标准的JSON数据
        /// 例如：Json＝{t1:[{name:'数据name',type:'数据type'}]} 或 Json＝{t1:[{name:'数据name',type:'数据type'}],t2:[{id:'数据id',gx:'数据gx',val:'数据val'}]}
        /// </summary>
        /// <param name="Json">Json字符串</param>
        /// <returns>DataSet</returns>
        public static DataSet JsonToDataSet(string Json)
        {
            try
            {
                DataSet ds = new DataSet();
                JavaScriptSerializer JSS = new JavaScriptSerializer();

                JSS.MaxJsonLength = Int32.MaxValue; //取得最大数值,代码在对象过大时会报错
                object obj = JSS.DeserializeObject(Json);
                Dictionary<string, object> datajson = (Dictionary<string, object>)obj;


                foreach (var item in datajson)
                {
                    DataTable dt = new DataTable(item.Key);

                    object[] rows = (object[])item.Value;
                    foreach (var row in rows)
                    {
                        Dictionary<string, object> val = (Dictionary<string, object>)row;
                        DataRow dr = dt.NewRow();
                        foreach (KeyValuePair<string, object> sss in val)
                        {
                            AddToRow(dt, dr, sss);
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void AddToRow(DataTable dt, DataRow dr, KeyValuePair<string, object> keyValue)
        {
            string key = keyValue.Key;
            object value = keyValue.Value;
            Type type = System.Type.GetType("System.String");

            if (key.Contains("date") || key.Equals("created"))
            {
                String dateStr = value.ToString();
                DateTimeFormatInfo dtfi = new CultureInfo("zh-CN", false).DateTimeFormat;
                DateTime dateTime = DateTime.ParseExact(dateStr, "yyyy-MM-ddThh:mm:sszzz", dtfi, DateTimeStyles.None);
                value = dateTime;
                type = dateTime.GetType();
            }

            if (!dt.Columns.Contains(key))
            {
                
                decimal tmp = 0;
                if (!key.Equals("stockid") && decimal.TryParse(value.ToString(), out tmp))
                {
                    type = System.Type.GetType("System.Decimal");
                }
                dt.Columns.Add(key, type);

                dr[key] = value;
            }
            else
                dr[key] = value;
        }

        /// <summary>
        /// 将DataSet转化成JSON数据
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToJson(DataSet ds)
        {
            string json = string.Empty;
            try
            {
                if (ds.Tables.Count == 0)
                    throw new Exception("DataSet中Tables为0");
                json = "{";
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    json += "T" + (i + 1) + ":[";
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        json += "{";
                        for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                        {
                            json += ds.Tables[i].Columns[k].ColumnName + ":'" + ds.Tables[i].Rows[j][k].ToString() + "'";
                            if (k != ds.Tables[i].Columns.Count - 1)
                                json += ",";
                        }
                        json += "}";
                        if (j != ds.Tables[i].Rows.Count - 1)
                            json += ",";
                    }
                    json += "]";
                    if (i != ds.Tables.Count - 1)
                        json += ",";


                }
                json += "}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return json;
        }

        #region DataTable 转换为Json 字符串
        /// <summary>
        /// DataTable 对象 转换为Json 字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(this DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, ToStr(dataRow[dataColumn.ColumnName]));
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }

            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        }
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
        #endregion

        #region 转换为string字符串类型
        /// <summary>
        ///  转换为string字符串类型
        /// </summary>
        /// <param name="s">获取需要转换的值</param>
        /// <param name="format">需要格式化的位数</param>
        /// <returns>返回一个新的字符串</returns>
        public static string ToStr(this object s, string format = "")
        {
            string result = "";
            try
            {
                if (format == "")
                {
                    result = s.ToString();
                }
                else
                {
                    result = string.Format("{0:" + format + "}", s);
                }
            }
            catch
            {
            }
            return result;
        }
        #endregion

        public static DataSet GetCrossInfo(double weight, String optName, String startDate, String endDate)
        {
            string jsonText = "";

            try
            {
                //FileStream aFile = new FileStream("crossinfo.txt", FileMode.OpenOrCreate);
                //StreamReader sr = new StreamReader(aFile, UnicodeEncoding.GetEncoding("GB2312"));
                //jsonText = sr.ReadToEnd();

                //sr.Close();
                
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "listcrossinfo";
                args["response"] = "json";
                args["starttime"] = startDate;
                args["endtime"] = endDate;
                args["optname"] = optName;
                args["weight"] = weight.ToString();
                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");

            return jsDs;
        }
        public static DataSet GetRaisingLimitInfo(ArrayList stockid, String sortname, bool asc, String startDate, String endDate, int page, int pagesize, out int totalpage, out int errorNo)
        {
            string jsonText = "";
            totalpage = 1;
            errorNo = 0;

            try
            {
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "listraisinglimitinfo";
                args["response"] = "json";
                if (stockid.Count != 0)
                {
                    args["stockid"] = String.Join(",", stockid.ToArray());
                }
                args["starttime"] = startDate;
                args["endtime"] = endDate;
                if (sortname.Trim().Length != 0)
                {
                    args["sortname"] = sortname;
                    args["asc"] = asc.ToString();
                }
                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");
            totalpage = Convert.ToInt32(num) / pagesize + 1;

            return jsDs;
        }
        public static DataSet GetRaisingLimitDay(String startDate, String endDate, int page, int pagesize, out int totalpage, out int errorNo)
        {
            string jsonText = "";
            totalpage = 1;
            errorNo = 0;

            try
            {
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "listraisinglimitinfoday";
                args["response"] = "json";
                args["starttime"] = startDate;
                args["endtime"] = endDate;

                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");
            totalpage = Convert.ToInt32(num) / pagesize + 1;

            return jsDs;
        }
        public static DataSet GetRaisingLimitInterval(ArrayList stockid, String sortname, bool asc, String startDate, String endDate, int page, int pagesize, out int totalpage, out int errorNo)
        {
            string jsonText = "";
            totalpage = 1;
            errorNo = 0;

            try
            {
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "listraisinglimitinfointerval";
                args["response"] = "json";
                if (stockid.Count != 0)
                {
                    args["stockid"] = String.Join(",", stockid.ToArray());
                }
                args["starttime"] = startDate;
                args["endtime"] = endDate;
                if (sortname.Trim().Length != 0)
                {
                    args["sortname"] = sortname;
                    args["asc"] = asc.ToString();
                }
                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");
            totalpage = Convert.ToInt32(num) / pagesize + 1;

            return jsDs;
        }
        public static DataSet GetStockStop(ArrayList stockid, String sortname, bool asc, String startDate, String endDate, int page, int pagesize, out int totalpage, out int errorNo)
        {
            string jsonText = "";
            totalpage = 1;
            errorNo = 0;

            try
            {
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "liststockstop";
                args["response"] = "json";
                if (stockid.Count != 0)
                {
                    args["stockid"] = String.Join(",", stockid.ToArray());
                }
                args["starttime"] = startDate;
                args["endtime"] = endDate;
                if (sortname.Trim().Length != 0)
                {
                    args["sortname"] = sortname;
                    args["asc"] = asc.ToString();
                }
                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");
            totalpage = Convert.ToInt32(num) / pagesize + 1;

            return jsDs;
        }
        public static DataSet GetGrowthBoard(String startDate, String endDate, int weight, out int totalpage, out int errorNo)
        {
            string jsonText = "";
            totalpage = 1;
            errorNo = 0;

            try
            {
                string url = localURL;
                Dictionary<string, string> args = new Dictionary<string, string>();
                args["command"] = "listgrowthboard";
                args["response"] = "json";
                args["starttime"] = startDate;
                args["endtime"] = endDate;
                args["weight"] = weight.ToString();
                jsonText = Http.Post(url, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return null;
            }

            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return new DataSet();
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            DataSet jsDs = JsonToDataSet("{" + jsonarray + "}");

            return jsDs;
        }
        public static bool CallApi(String api,out int totalPage, out DataSet ds)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            return CallApi(api, args, out totalPage, out ds);
        }
        public static bool CallApi(String api, out DataSet ds)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            int totalPage;
            return CallApi(api, args, out totalPage, out ds);
        }
        public static bool CallApi(String api,Dictionary<string, string> args, out DataSet ds)
        {
            int totalPage;
            return CallApi(api, args, out totalPage, out ds);
        }
        public static bool CallApi(String api, Dictionary<string, string> args, out int totalpage, out DataSet ds)
        {
            args["command"] = api;
            args["response"] = "json";
            return CallApi(args, out totalpage, out ds);
        }
        public static bool CallApi(Dictionary<string, string> args, out int totalpage, out DataSet ds)
        {
            String jsonText = "";
            totalpage = 1;
            ds = null;
            try
            {
                jsonText = Http.Get(localURL, args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return false;
            }
            catch (WebException ex)
            {
                Console.WriteLine("An WebException has been thrown!");
                Console.WriteLine(ex.ToString());
                return false;
            }
            JObject jo = JObject.Parse(jsonText);

            if (jo.First.First.Last == null)
            {
                return false;
            }

            string jsonarray = jo.First.First.Last.ToString();
            string num = jo.First.First.First.First.ToString();
            ds = JsonToDataSet("{" + jsonarray + "}");
            if (args.Keys.Contains("pagesize"))
            {
                totalpage = Convert.ToInt32(num) / Convert.ToInt32(args["pagesize"]) + 1;
            }
            return true;
        }
    }
}
