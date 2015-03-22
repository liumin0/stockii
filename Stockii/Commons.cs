using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stockii
{
    
    public class Commons
    {

        public static List<DateTime> tradeDates = new List<DateTime>();
        public static DataTable classificationTable = new DataTable();
        public static SerializableDictionary<String, List<string>> groupDict = new SerializableDictionary<string, List<string>>();
        public static Dictionary<String, List<string>> areaDict = new Dictionary<string, List<string>>();
        public static Dictionary<String, List<string>> industryDict = new Dictionary<string, List<string>>();
        public static List<BarCheckItem> menuItems = new List<BarCheckItem>();
        public static Property property = LoadProperty();
        public static DataTable combineUndoTable = new DataTable();
        public static SerializableDictionary<String, List<SavedAction>> combineDict = LoadCombine();
        public static List<SavedAction> combineUndoActions = new List<SavedAction>();
        public static List<SavedAction> combineCurActions = new List<SavedAction>();
        public static Dictionary<string, string> userInfos = new Dictionary<string, string>();
        public static List<BarItem> unUseRibbonItems = new List<BarItem>();
        public static string token = "";
        public static int permissionLevel = 0;

        [Serializable]
        public class SavedAction
        {
            public List<string> headers = new List<string>();
            public SerializableDictionary<string, string> args = new SerializableDictionary<string, string>();
        }
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
            LoadGroupInfo();
            return true;
        }

        private static void LoadGroupInfo()
        {
            try
            {
                if (File.Exists(Constants.groupConfigPath))
                {
                    groupDict = MySerializer.LoadFromXml(Constants.groupConfigPath, groupDict.GetType()) as SerializableDictionary<String, List<string>>;
                    //using (FileStream fileStream = new FileStream(Constants.groupConfigPath, FileMode.Open))
                    //{
                    //    XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, List<string>>));
                    //    groupDict = (SerializableDictionary<string, List<string>>)xmlFormatter.Deserialize(fileStream);
                    //}

                }
            }
            catch (Exception)
            {
            }
            
            groupDict["全部股票"] = new List<string>();
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
                    classificationTable = dt.Copy();
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
                catch (Exception)
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
                        DateTime dateTime = (DateTime)row["listdate"];
                        //DateTimeFormatInfo dtfi = new CultureInfo("zh-CN", false).DateTimeFormat;
                        //DateTime dateTime = row["listdate"] as DateTime;
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
        /// 计算当前日期n个交易日之后的日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="count"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool AddTradeDay(DateTime date, int count, out DateTime result)
        {
            DateTime riqi = Convert.ToDateTime(date.ToShortDateString() + "T00:00:00" + date.ToString("zzz"));
            result = riqi;
            int index = -1;
            for (int i = 0; i < tradeDates.Count; i++)
            {
                if (tradeDates[i] >= riqi)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0 || index + count >= tradeDates.Count)
            {
                return false;
            }
            result = tradeDates[index + count];
            return true;
        }

        /// <summary>
        /// 计算当前日期n个交易日之前的日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="count"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool MinusTradeDay(DateTime date, int count, out DateTime result)
        {
            DateTime riqi = Convert.ToDateTime(date.ToShortDateString() + "T00:00:00" + date.ToString("zzz"));
            result = riqi;
            int index = -1;
            for (int i = tradeDates.Count - 1; i >= 0; i--)
            {
                if (tradeDates[i] <= riqi)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0 || index - count < 0)
            {
                return false;
            }
            result = tradeDates[index - count];
            return true;
        }

        /// <summary>
        /// 保存分组信息
        /// </summary>
        public static void SaveGroup()
        {
            MySerializer.SaveToXml(Constants.groupConfigPath, groupDict);
            //using (FileStream fileStream = new FileStream(Constants.groupConfigPath, FileMode.Create))
            //{
            //    XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, List<string>>));
            //    xmlFormatter.Serialize(fileStream, groupDict);
            //}
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="name">分组名称</param>
        public static void DeleteGroup(string name)
        {
            groupDict.Remove(name);
            SaveGroup();
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="name">分组名称</param>
        /// <param name="list">新分组内容</param>
        public static void EditGroup(string name, List<string> list)
        {
            groupDict[name] = list;
            SaveGroup();
        }

        /// <summary>
        /// 保存设置信息
        /// </summary>
        public static void SaveProperty()
        {
            MySerializer.SaveToXml(Constants.propertyPath, property);
            //IFormatter formatter = new BinaryFormatter();

            //Stream stream = new FileStream(Constants.propertyPath, FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, property);

            //stream.Close(); 
        }

        /// <summary>
        /// 读取设置信息
        /// </summary>
        /// <returns></returns>
        public static Property LoadProperty()
        {
            try
            {
                if (File.Exists(Constants.propertyPath))
                {
                    return MySerializer.LoadFromXml(Constants.propertyPath, typeof(Property)) as Property;
                    //using (FileStream stream = new FileStream(Constants.propertyPath, FileMode.Open, FileAccess.Read))
                    //{
                    //    BinaryFormatter binary = new BinaryFormatter();
                    //    Property property = (Property)binary.Deserialize(stream);
                    //    return property;
                    //}
                }
            }
            catch (Exception)
            {
            }
            
            return new Property();
        }

        /// <summary>
        /// 保存拼接表中的数据，undo的时候恢复
        /// </summary>
        /// <param name="combineControl"></param>
        public static void SaveToUndo(GridControl combineControl)
        {
            DataTable combineTable = combineControl.DataSource as DataTable;
            if (combineTable != null)
            {
                combineUndoTable = combineTable.Copy();
                combineUndoActions.Clear();
                foreach (SavedAction action in combineCurActions)
                {
                    combineUndoActions.Add(action);
                }
            }
        }

        /// <summary>
        /// 拼接表中的数据绑定
        /// </summary>
        /// <param name="combineControl"></param>
        /// <param name="dt"></param>
        public static void BindCombineData(GridControl combineControl, DataTable dt)
        {
            GridView combineGridView = combineControl.MainView as GridView;
            combineGridView.Columns.Clear();
            combineControl.DataSource = dt;
        }

        /// <summary>
        /// 执行拼接操作
        /// </summary>
        /// <param name="srcControl">原表</param>
        /// <param name="combineControl">拼接表</param>
        /// <param name="isSelect">是否是拼接选中</param>
        public static void Combine(GridControl srcControl, GridControl combineControl, bool isSelect)
        {
            
            GridView dataGridView = srcControl.MainView as GridView;
            GridView combineGridView = combineControl.MainView as GridView;
            DataTable tb1 = srcControl.DataSource as DataTable;
            DataTable tb2 = new DataTable();//临时表
            SaveToUndo(combineControl);
            SavedAction act = new SavedAction();
            Dictionary<string,string> args = srcControl.Tag as Dictionary<string, string>;
            foreach (string key in args.Keys)
            {
                if (!key.Equals("stockid") && !key.Equals("starttime") && !key.Equals("endtime"))
                {
                    act.args[key] = args[key];
                }
            }
            foreach (GridColumn c in dataGridView.Columns)
            {
                tb2.Columns.Add(c.Caption, c.ColumnType);
                act.headers.Add(c.Caption);
            }
            combineCurActions.Add(act);
            
            //生成临时表保存选中或全部列
            if (isSelect)
            {
                //for (int r = dataGridView.SelectedRowsCount - 1; r >= 0; r--)
                foreach (int r in dataGridView.GetSelectedRows())
                {
                    DataRow dataRow = tb2.NewRow();
                    foreach (GridColumn column in dataGridView.Columns)
	                {
		                dataRow[column.Caption] = dataGridView.GetRowCellValue(r, column);
	                }
                    tb2.Rows.Add(dataRow);
                }
            }
            else
            {
                for (int r = 0; r < dataGridView.RowCount; r++ )
                {
                    DataRow dataRow = tb2.NewRow();
                    foreach (GridColumn column in dataGridView.Columns)
                    {
                        dataRow[column.Caption] = dataGridView.GetRowCellValue(r, column);
                    }
                    tb2.Rows.Add(dataRow);
                }
            }

            if (combineGridView.RowCount > 0)
            {
                DataTable tb3 = combineControl.DataSource as DataTable;
                BindCombineData(combineControl, CombineDt(tb2, tb3));
            }
            else
            {
                combineControl.DataSource = tb2;
            }
        }

        /// <summary>
        /// 拼接两个DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="combineDt"></param>
        /// <returns></returns>
        public static DataTable CombineDt(DataTable table, DataTable combineDt)
        {
            DataTable tb2 = table;
            if (combineDt.Rows.Count > 0)
            {
                DataTable tb4 = new DataTable();//临时表
                tb4 = combineDt.Copy();

                ArrayList host = new ArrayList();
                ArrayList client = new ArrayList();
                for (int i = tb4.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = tb4.Rows[i];
                    for (int j = tb2.Rows.Count - 1; j >= 0; j--)
                    {
                        DataRow re = tb2.Rows[j];
                        if (re[0].ToString() == dr[0].ToString())//相同ID则拼接
                        {
                            //要保留的
                            host.Add(i);
                            client.Add(j);
                            break;
                        }
                    }
                }

                //Intersaction(ref tb2,ref tb4, host, client);
                Union(ref tb2, ref tb4, host, client);

                return tb4;
            }
            else
            {
                return tb2;
            }
        }

        /// <summary>
        /// 求两个DataTable的交集
        /// </summary>
        /// <param name="tb2">host</param>
        /// <param name="tb4">client</param>
        /// <param name="host">tb4相同的ID索引</param>
        /// <param name="client">tb2相同的ID索引</param>
        public static void Intersaction(ref DataTable tb2, ref DataTable tb4, ArrayList host, ArrayList client)
        {
            for (int i = tb4.Rows.Count - 1; i >= 0; i--)
            {
                if (!host.Contains(i))
                    tb4.Rows.RemoveAt(i);
            }
            for (int i = tb2.Rows.Count - 1; i >= 0; i--)
            {
                if (!client.Contains(i))
                    tb2.Rows.RemoveAt(i);
            }

            AppendDataTable(tb4, tb2);
        }

        /// <summary>
        /// 求两个DataTable的并集
        /// </summary>
        /// <param name="tb2">host</param>
        /// <param name="tb4">client</param>
        /// <param name="host">tb4相同的ID索引</param>
        /// <param name="client">tb2相同的ID索引</param>
        public static void Union(ref DataTable tb2, ref DataTable tb4, ArrayList host, ArrayList client)
        {
            DataTable tb1 = tb4.Clone();//包含tb4中与tb2不同的ID的数据项
            DataTable tb3 = tb2.Clone();//包含tb2中与tb4不同的ID的数据项
            for (int i = tb4.Rows.Count - 1; i >= 0; i--)
            {
                if (!host.Contains(i))
                {
                    tb1.ImportRow(tb4.Rows[i]);
                    DataRow drq = tb3.NewRow();
                    tb3.Rows.Add(drq);

                    tb4.Rows.RemoveAt(i);
                }
            }

            for (int i = tb2.Rows.Count - 1; i >= 0; i--)
            {
                if (!client.Contains(i))
                {
                    tb3.ImportRow(tb2.Rows[i]);
                    DataRow drq = tb1.NewRow();
                    tb1.Rows.Add(drq);

                    tb2.Rows.RemoveAt(i);
                }

            }

            AppendDataTable(tb4, tb2);
            AppendDataTable(tb1, tb3);

            //tb1加到tb4
            object[] obj = new object[tb4.Columns.Count];

            for (int i = 0; i < tb1.Rows.Count; i++)
            {
                tb1.Rows[i].ItemArray.CopyTo(obj, 0);
                tb4.Rows.Add(obj);
            }
        }
        /// <summary>
        /// 将两个DataTable纵向合并
        /// </summary>
        /// <param name="hostDt">主表</param>
        /// <param name="clientDt">拼接表</param>
        public static void AppendDataTable(DataTable hostDt, DataTable clientDt)
        {
            if (hostDt != null)
            {
                DataRow dr;
                
                for (int i = 0; i < clientDt.Columns.Count; i++)
                {
                    string colName = clientDt.Columns[i].ColumnName;
                    int count = 0;
                    while (hostDt.Columns.Contains(colName))
                    {
                        colName = clientDt.Columns[i].ColumnName + ++count;
                    }
                    hostDt.Columns.Add(clientDt.Columns[i].ColumnName + count, clientDt.Columns[i].DataType);

                    if (clientDt.Rows.Count > 0)
                        for (int j = 0; j < clientDt.Rows.Count; j++)
                        {
                            dr = hostDt.Rows[j];
                            dr[hostDt.Columns.Count - 1] = clientDt.Rows[j][i];
                            dr = null;
                        }
                }
            }
        }

        /// <summary>
        /// MD5加密算法
        /// </summary>
        /// <param name="strText">待加密字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("X2"));
            }
            return sb.ToString();  
        }

        /// <summary>
        /// 保存拼接操作
        /// </summary>
        /// <param name="name"></param>
        public static void SaveCombine(string name)
        {
            if (!combineDict.Keys.Contains(name))
	        {
                List<SavedAction> act = new List<SavedAction>();
                combineCurActions.ForEach(i => act.Add(i));
                combineDict[name] = act;
                MySerializer.SaveToXml(Constants.combinePath, combineDict);
	        }
        }

        /// <summary>
        /// 加载保存的拼接操作
        /// </summary>
        /// <returns></returns>
        public static SerializableDictionary<String, List<SavedAction>> LoadCombine()
        {
            try
            {
                return MySerializer.LoadFromXml(Constants.combinePath, typeof(SerializableDictionary<String, List<SavedAction>>)) as SerializableDictionary<String, List<SavedAction>>;
            }
            catch (Exception)
            {
            }
            return new SerializableDictionary<String, List<SavedAction>>();
        }

        /// <summary>
        /// 判断开始和结束时间是否有效
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool ValidateDate(DateTime start, DateTime end)
        {
            #region 判断时间是否有效
            //*
            if (start > end)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("开始时间大于结束时间，请重新输入");
                return false;
            }
            if (!Commons.IsTradeDay(start))
            {
                //TODO
                DevExpress.XtraEditors.XtraMessageBox.Show("开始时间非交易日，请重新输入");
                return false;
            }
            if (!Commons.IsTradeDay(end))
            {
                //TODO
                DevExpress.XtraEditors.XtraMessageBox.Show("结束时间非交易日，请重新输入");
                return false;
            }
            //*/
            return true;
            #endregion
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        public static void LoadUserInfo()
        {
            if (File.Exists(Constants.userInfoPath))
            {
                FileStream fileStream = new FileStream(Constants.userInfoPath, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
                fileStream.Seek(0, SeekOrigin.Begin);
                string content = streamReader.ReadLine();
                while (content != null)
                {
                    string text = Crypto.DecryptDES(content.Trim());
                    string[] splitText = text.Split(' ');
                    try
                    {
                        userInfos[splitText[0]] = splitText[1];
                    }
                    catch (Exception)
                    {
                    }
                    content = streamReader.ReadLine();
                }
                streamReader.Close();
                fileStream.Close();
            }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        public static void SaveUserInfo()
        {

            FileStream fileStream = new FileStream(Constants.userInfoPath, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            fileStream.Seek(0, SeekOrigin.Begin);
            foreach (string key in userInfos.Keys)
            {
                string text = key + " " + userInfos[key];
                string encryptText = Crypto.EncryptDES(text);
                streamWriter.WriteLine(encryptText);
            }
            streamWriter.Close();
            fileStream.Close();
        }

    }
}
