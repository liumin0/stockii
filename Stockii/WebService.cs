using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net; 
using System.Text;
using System.Threading.Tasks;

namespace Stockii
{
    class WebService
    {
          
        public static bool Login(string userName, string passwd)
        {
            string passwdMd5 = Commons.MD5Encrypt(passwd);
            return JSONHandler.Login(userName, passwdMd5);
        }
        public static bool GetTradeDate(out DataSet ds)
        {
            return JSONHandler.CallApi("listtradedate", out ds);
        }
        public static bool GetClassfication(out DataSet ds)
        {
            return JSONHandler.CallApi("liststockclassification", out ds);
        }
        public static bool GetStockDayInfo(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("liststockdayinfo", args, out totalPage, out ds);
        }
        public static bool GetDaySum(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listdaysum", args, out totalPage, out ds);
        }
        public static bool GetWeekSum(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listweeksum", args, out totalPage, out ds);
        }
        public static bool GetMonthSum(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listmonthsum", args, out totalPage, out ds);
        }
        public static bool GetGrowthAmpDis(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listgrowthampdis", args, out totalPage, out ds);
        }
        public static bool GetNDaysSum(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listndayssum", args, out totalPage, out ds);
        }
        public static bool GetStockDaysDiff(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("liststockdaysdiff", args, out totalPage, out ds);
        }
        public static bool GetCrossInfo(Dictionary<string, string> args, out DataSet ds)
        {
            return JSONHandler.CallApi("listcrossinfo", args, out ds);
        }
        public static bool GetRaisingLimitInfo(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listraisinglimitinfo", args, out totalPage, out ds);
        }
        public static bool GetRaisingLimitInfoDay(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listraisinglimitinfoday", args, out totalPage, out ds);
        }
        public static bool GetRaisingLimitInfoInterval(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listraisinglimitinfointerval", args, out totalPage, out ds);
        }
        public static bool GetStockStop(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("liststockstop", args, out totalPage, out ds);
        }
        public static bool GetGrowthBoard(Dictionary<string, string> args, out int totalPage, out DataSet ds)
        {
            return JSONHandler.CallApi("listgrowthboard", args, out totalPage, out ds);
        }
    }
}
