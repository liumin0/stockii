using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockii
{
    public class Constants
    {
        public static string configDir = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stockii";
        public static string dockLayoutPath = configDir + "\\dockLayout.xml";
        public static string groupConfigPath = configDir + "\\groupInfo.xml";
        public static string propertyPath = configDir + "\\property.xml";
        public static string combinePath = configDir + "\\combine.xml";
        public static string userInfoPath = configDir + "\\userInfo.dat";

        public static List<string> customSortList = new List<string> {
                "liststockdayinfo",
                "nDayCalTab",
                "listraisinglimitinfo",
                "listraisinglimitinfointerval",
                "liststockstop",
        };

        public static Dictionary<string, string> nDayIndexDict = new Dictionary<string, string>{
            #region N日和指标字典
                {"均价","avg_price"},
                {"涨幅","growth"},
                {"换手","turn"},
                {"振幅","amp"},
                {"总金额","total"},
                {"量比","vol"}
            #endregion
        };

        public static Dictionary<string, string> nDayTypeDict = new Dictionary<string, string>{
            #region N日和类型字典
                {"正和","positive"},
                {"负和","negative"},
                {"所有和","all"}
            #endregion
        };

        public static Dictionary<string, string> customCalTypeDict = new Dictionary<string, string>{
            #region 自定义计算方法字典
                {"指定两天加","plus"},
                {"指定两天减","minus"},
                {"指定两天比值","divide"},
                {"指定时间段内最大值减最小值","maxmin"},
                {"指定时间段内最大值比最小值","maxmindivide"},
                {"指定时间段内的和","sum"},
                {"两个时间内涨幅,振幅数据分段","seperate"}
            #endregion
        };

        public static Dictionary<string, string> customCalIndexDict = new Dictionary<string, string>{
            #region 自定义计算指标字典
                {"均价","avg_price"},
                {"涨幅","growth_ratio"},
                {"总股本","total_stock"},
                {"总市值","total_value"},
                {"均价流通市值","avg_circulation_value"},
                {"流通股本","cir_of_cap_stock"},
                {"现价","current_price"},
                {"换手","turnover_ratio"},
                {"总金额","total_money"},
                {"振幅","amplitude_ratio"},
                {"量比","volume_ratio"}
            #endregion
        };

        public static Dictionary<string, string> crossIndexDict = new Dictionary<string, string>{
            #region 跨区指标字典
                {"昨收","ytd_end_price"},
                {"均价","avg_price"}, 
                {"均价流通市值","avg_circulation_value"},
                {"总市值","total_value"},
                {"总股本","total_stock"},
                {"流通股本","cir_of_cap_stock"}
            #endregion
        };

        public class IndexInfo
        {
            public string fieldName;
            public string name;
            public string unit;
            public string format;
            public IndexInfo(string aField, string aName, string aUnit, string aFormat)
            {
                fieldName = aField;
                name = aName;
                unit = aUnit;
                format = aFormat;
            }
        }

        public static Dictionary<string, IndexInfo> translateDict = new Dictionary<string, IndexInfo>{
            #region 翻译字典
                {"stock_id", new IndexInfo("stock_id", "代码", "", "")},
                {"stock_name", new IndexInfo("stock_name", "名称", "", "")},                                                                 
                {"stockname", new IndexInfo("stockname", "名称", "", "")},                                                                 
                {"name", new IndexInfo("name", "名称", "", "")},                                                                  
                {"created", new IndexInfo("created", "日期", "", "")},                                                                 
                {"growth_ratio", new IndexInfo("growth_ratio", "涨幅", "%", "f2")},                                                                 
                {"current_price", new IndexInfo("current_price", "现价", "元", "f2")},                                                                 
                {"daily_up_down", new IndexInfo("daily_up_down", "日涨跌", "元", "f2")},                                                                 
                {"bought_price", new IndexInfo("bought_price", "买入价", "元", "f2")},                                                                 
                {"sold_price", new IndexInfo("sold_price", "卖出价", "元", "f2")},                                                                 
                {"total_deal_amount", new IndexInfo("total_deal_amount", "总量", "", "f2")},                                                                 
                {"last_deal_amount", new IndexInfo("last_deal_amount", "现量", "", "f2")},                                                                 
                {"growth_speed", new IndexInfo("growth_speed", "涨速", "%", "f2")},                                                                 
                {"turnover_ratio", new IndexInfo("turnover_ratio", "换手", "%", "f2")},                                                                 
                {"today_begin_price", new IndexInfo("today_begin_price", "今开", "元", "f2")},                                                                 
                {"ytd_end_price", new IndexInfo("ytd_end_price", "昨收", "元", "f2")},                                                                 
                {"pe_ratio", new IndexInfo("pe_ratio", "市盈率", "", "f2")},                                                                 
                {"max", new IndexInfo("max", "最高", "元", "f2")},                                                                 
                {"min", new IndexInfo("min", "最低", "元", "f2")},                                                                 
                {"total_money", new IndexInfo("total_money", "总金额", "亿元", "f4")},                                                                 
                {"amplitude_ratio", new IndexInfo("amplitude_ratio", "振幅", "%", "f2")},                                                                 
                {"cir_of_cap_stock", new IndexInfo("cir_of_cap_stock", "流通股本", "亿股", "f4")},                                                                 
                {"upordown_per_deal", new IndexInfo("upordown_per_deal", "笔涨跌", "", "f2")},                                                                 
                {"volume_ratio", new IndexInfo("volume_ratio", "量比", "", "f2")},                                                                 
                {"avg_price", new IndexInfo("avg_price", "均价", "元", "f2")},                                                                 
                {"DaPanWeiBi", new IndexInfo("DaPanWeiBi", "委比", "", "f2")},                                                                 
                {"sell", new IndexInfo("sell", "内盘", "", "f2")},                                                                 
                {"buy", new IndexInfo("buy", "外盘", "", "f2")},                                                                 
                {"sb_ratio", new IndexInfo("sb_ratio", "内外比", "", "f2")},                                                                 
                {"DaPanWeiCha", new IndexInfo("DaPanWeiCha", "委量差", "", "f2")},                                                                 
                {"num1_buy", new IndexInfo("num1_buy", "买量一", "", "f2")},                                                                 
                {"num1_sell", new IndexInfo("num1_sell", "卖量一", "", "f2")},                                                                 
                {"num1_buy_price", new IndexInfo("num1_buy_price", "买价一", "元", "f2")},                                                                 
                {"num1_sell_price", new IndexInfo("num1_sell_price", "卖价一", "元", "f2")},                                                                 
                {"num2_buy", new IndexInfo("num2_buy", "卖价二", "元", "f2")},                                                                 
                {"num2_sell", new IndexInfo("num2_sell", "卖量二", "", "f2")},                                                                 
                {"num2_buy_price", new IndexInfo("num2_buy_price", "买价二", "元", "f2")},                                                                 
                {"num2_sell_price", new IndexInfo("num2_sell_price", "买量二", "", "f2")},                                                                 
                {"num3_buy", new IndexInfo("num3_buy", "买价三", "元", "f2")},                                                                 
                {"num3_sell", new IndexInfo("num3_sell", "买量三", "", "f2")},                                                                 
                {"num3_buy_price", new IndexInfo("num3_buy_price", "卖价三", "元", "f2")},                                                                 
                {"num3_sell_price", new IndexInfo("num3_sell_price", "卖量三", "", "f2")},                                                                 
                {"circulation_value", new IndexInfo("circulation_value", "流通市值", "亿元", "f4")},                                                                 
                {"bbi_balance", new IndexInfo("bbi_balance", "多空平衡", "元", "f2")},                                                                 
                {"bull_profit", new IndexInfo("bull_profit", "多头获利", "元", "f2")},                                                                 
                {"bull_stop_losses", new IndexInfo("bull_stop_losses", "多头止损", "元", "f2")},                                                                 
                {"short_covering", new IndexInfo("short_covering", "空头回补", "", "f2")},                                                                 
                {"bear_stop_losses", new IndexInfo("bear_stop_losses", "空头止损", "", "f2")},                                                                 
                {"relative_strength_index", new IndexInfo("relative_strength_index", "强弱度", "", "f2")},                                                                 
                {"activity", new IndexInfo("activity", "活跃度", "", "f2")},                                                                 
                {"num_per_deal", new IndexInfo("num_per_deal", "每笔均量", "", "f2")},                                                                 
                {"turn_per_deal", new IndexInfo("turn_per_deal", "每笔换手", "", "f2")},                                                                 
                {"update_date", new IndexInfo("update_date", "更新日期", "", "")},                                                                 
                {"total_stock", new IndexInfo("total_stock", "总股本", "亿股", "f4")},                                                                 
                {"max_circulation_value", new IndexInfo("max_circulation_value", "最高价流通市值", "亿元", "f4")},                                                                 
                {"current_circulation_value", new IndexInfo("current_circulation_value", "现价流通市值", "亿元", "f4")},                                                                 
                {"min_circulation_value", new IndexInfo("min_circulation_value", "最低价流通市值", "亿元", "f4")},                                                                 
                {"avg_circulation_value", new IndexInfo("avg_circulation_value", "均价流通市值", "亿元", "f4")},                                                                 
                {"total_value", new IndexInfo("total_value", "总市值", "亿元", "f4")},                                                                  
                {"stockid", new IndexInfo("stockid", "代码", "", "")},                                                                   
                {"listdate", new IndexInfo("listdate", "日期", "", "")},                                                                  
                {"onemonthsum", new IndexInfo("onemonthsum", "1月和", "#", "#")},    
                {"twomonthsum", new IndexInfo("twomonthsum", "2月和", "#", "#")},
                {"threemonthsum", new IndexInfo("threemonthsum", "3月和", "#", "#")},
                {"fourmonthsum", new IndexInfo("fourmonthsum", "4月和", "#", "#")},
                {"fivemonthsum", new IndexInfo("fivemonthsum", "5月和", "#", "#")},
                {"sixmonthsum", new IndexInfo("sixmonthsum", "6月和", "#", "#")},
                {"sevenmonthsum", new IndexInfo("sevenmonthsum", "7月和", "#", "#")},
                {"eightmonthsum", new IndexInfo("eightmonthsum", "8月和", "#", "#")},
                {"ninemonthsum", new IndexInfo("ninemonthsum", "9月和", "#", "#")},
                {"tenmonthsum", new IndexInfo("tenmonthsum", "10月和", "#", "#")},
                {"elevenmonthsum", new IndexInfo("elevenmonthsum", "11月和", "#", "#")},
                {"twelvemonthsum", new IndexInfo("twelvemonthsum", "12月和", "#", "#")},
                {"threesum", new IndexInfo("threesum", "3日和", "#", "#")},                                                                 
                {"foursum", new IndexInfo("foursum", "4日和", "#", "#")},                                                                 
                {"fivesum", new IndexInfo("fivesum", "5日和", "#", "#")},                                                                 
                {"sixsum", new IndexInfo("sixsum", "6日和", "#", "#")},                                                                 
                {"sevensum", new IndexInfo("sevensum", "7日和", "#", "#")},                                                                 
                {"eightsum", new IndexInfo("eightsum", "8日和", "#", "#")},                                                                 
                {"ninesum", new IndexInfo("ninesum", "9日和", "#", "#")},                                                                 
                {"tensum", new IndexInfo("tensum", "10日和", "#", "#")},                                                                 
                {"elevensum", new IndexInfo("elevensum", "11日和", "#", "#")},                                                                 
                {"twelvesum", new IndexInfo("twelvesum", "12日和", "#", "#")},                                                                 
                {"thirteensum", new IndexInfo("thirteensum", "13日和", "#", "#")},                                                                 
                {"fourteensum", new IndexInfo("fourteensum", "14日和", "#", "#")},                                                                 
                {"fifteensum", new IndexInfo("fifteensum", "15日和", "#", "#")},                                                                 
                {"sixteensum", new IndexInfo("sixteensum", "16日和", "#", "#")},                                                                 
                {"seventeensum", new IndexInfo("seventeensum", "17日和", "#", "#")},                                                                 
                {"eighteensum", new IndexInfo("eighteensum", "18日和", "#", "#")},                                                                 
                {"nineteensum", new IndexInfo("nineteensum", "19日和", "#", "#")},                                                                 
                {"twentysum", new IndexInfo("twentysum", "20日和", "#", "#")},                                                                 
                {"twenty1sum", new IndexInfo("twenty1sum", "21日和", "#", "#")},                                                                 
                {"twenty2sum", new IndexInfo("twenty2sum", "22日和", "#", "#")},                                                                 
                {"twenty3sum", new IndexInfo("twenty3sum", "23日和", "#", "#")},                                                                 
                {"twenty4sum", new IndexInfo("twenty4sum", "24日和", "#", "#")},                                                                 
                {"twenty5sum", new IndexInfo("twenty5sum", "25日和", "#", "#")},                                                                 
                {"twenty6sum", new IndexInfo("twenty6sum", "26日和", "#", "#")},                                                                 
                {"twenty7sum", new IndexInfo("twenty7sum", "27日和", "#", "#")},                                                                 
                {"twenty8sum", new IndexInfo("twenty8sum", "28日和", "#", "#")},                                                                 
                {"twenty9sum", new IndexInfo("twenty9sum", "29日和", "#", "#")},                                                                 
                {"thirtysum", new IndexInfo("thirtysum", "30日和", "#", "#")},                                                                 
                {"oneweeksum", new IndexInfo("oneweeksum", "1周和", "#", "#")},                                                                 
                {"twoweeksum", new IndexInfo("twoweeksum", "2周和", "#", "#")},                                                                 
                {"threeweeksum", new IndexInfo("threeweeksum", "3周和", "#", "#")},                                                                 
                {"fourweeksum", new IndexInfo("fourweeksum", "4周和", "#", "#")},                                                                 
                {"fiveweeksum", new IndexInfo("fiveweeksum", "5周和", "#", "#")},                                                                 
                {"sixweeksum", new IndexInfo("sixweeksum", "6周和", "#", "#")},                                                                 
                {"growthcount", new IndexInfo("growthcount", "涨幅总数", "", "")},                                                                  
                {"ampcount", new IndexInfo("ampcount", "振幅总数", "", "")},                                                                  
                {"g0", new IndexInfo("g0", "涨幅小于-9个数", "", "")},                                                                 
                {"g1", new IndexInfo("g1", "涨幅[-9~-8)个数", "", "")},                                                                 
                {"g2", new IndexInfo("g2", "涨幅[-8~-7)个数", "", "")},                                                                 
                {"g3", new IndexInfo("g3", "涨幅[-7~-6)个数", "", "")},                                                                 
                {"g4", new IndexInfo("g4", "涨幅[-6~-5)个数", "", "")},                                                                 
                {"g5", new IndexInfo("g5", "涨幅[-5~-4)个数", "", "")},                                                                 
                {"g6", new IndexInfo("g6", "涨幅[-4~-3)个数", "", "")},                                                                 
                {"g7", new IndexInfo("g7", "涨幅[-3~-2)个数", "", "")},                                                                 
                {"g8", new IndexInfo("g8", "涨幅[-2~-1)个数", "", "")},                                                                 
                {"g9", new IndexInfo("g9", "涨幅[-1~0)个数", "", "")},                                                                 
                {"g10", new IndexInfo("g10", "涨幅[0~1)个数", "", "")},                                                                 
                {"g11", new IndexInfo("g11", "涨幅[1~2)个数", "", "")},                                                                 
                {"g12", new IndexInfo("g12", "涨幅[2~3)个数", "", "")},                                                                 
                {"g13", new IndexInfo("g13", "涨幅[3~4)个数", "", "")},                                                                 
                {"g14", new IndexInfo("g14", "涨幅[4~5)个数", "", "")},                                                                 
                {"g15", new IndexInfo("g15", "涨幅[5~6)个数", "", "")},                                                                 
                {"g16", new IndexInfo("g16", "涨幅[6~7)个数", "", "")},                                                                 
                {"g17", new IndexInfo("g17", "涨幅[7~8)个数", "", "")},                                                                 
                {"g18", new IndexInfo("g18", "涨幅[8~9)个数", "", "")},                                                                 
                {"g19", new IndexInfo("g19", "涨幅大于9个数", "", "")},                                                                 
                {"a0", new IndexInfo("a0", "振幅[0~1)个数", "", "")},                                                                 
                {"a1", new IndexInfo("a1", "振幅[1~2)个数", "", "")},                                                                 
                {"a2", new IndexInfo("a2", "振幅[2~3)个数", "", "")},                                                                 
                {"a3", new IndexInfo("a3", "振幅[3~4)个数", "", "")},                                                                 
                {"a4", new IndexInfo("a4", "振幅[4~5)个数", "", "")},                                                                 
                {"a5", new IndexInfo("a5", "振幅[5~6)个数", "", "")},                                                                 
                {"a6", new IndexInfo("a6", "振幅[6~7)个数", "", "")},                                                                 
                {"a7", new IndexInfo("a7", "振幅[7~8)个数", "", "")},                                                                 
                {"a8", new IndexInfo("a8", "振幅[8~9)个数", "", "")},                                                                 
                {"a9", new IndexInfo("a9", "振幅[9~10)个数", "", "")},                                                                 
                {"a10", new IndexInfo("a10", "振幅[10~11)个数", "", "")},                                                                 
                {"a11", new IndexInfo("a11", "振幅[11~12)个数", "", "")},                                                                 
                {"a12", new IndexInfo("a12", "振幅[12~13)个数", "", "")},                                                                 
                {"a13", new IndexInfo("a13", "振幅[13~14)个数", "", "")},                                                                 
                {"a14", new IndexInfo("a14", "振幅[14~15)个数", "", "")},                                                                 
                {"a15", new IndexInfo("a15", "振幅[15~16)个数", "", "")},                                                                 
                {"a16", new IndexInfo("a16", "振幅[16~17)个数", "", "")},                                                                 
                {"a17", new IndexInfo("a17", "振幅[17~18)个数", "", "")},                                                                 
                {"a18", new IndexInfo("a18", "振幅[18~19)个数", "", "")},                                                                 
                {"a19", new IndexInfo("a19", "振幅大于19个数", "", "")},                                                                 
                {"startvalue", new IndexInfo("startvalue", "起始时间的值", "#", "#")},                                                                  
                {"endvalue", new IndexInfo("endvalue", "结束时间的值", "#", "#")},                                                                  
                {"maxdate", new IndexInfo("maxdate", "最大值日期", "", "")},                                                                  
                {"mindate", new IndexInfo("mindate", "最小值日期", "", "")},                                                                  
                {"maxvalue", new IndexInfo("maxvalue", "最大值", "#", "#")},                                                                  
                {"minvalue", new IndexInfo("minvalue", "最小值", "#", "#")},                                                                 
                {"start_list_date", new IndexInfo("start_list_date", "开始-上市", "", "")},                                                                 
                {"end_list_date", new IndexInfo("end_list_date", "结束-上市", "", "")},                                                                 
                {"cross_type", new IndexInfo("cross_type", "跨区类型", "", "")},                                                                 
                {"avg", new IndexInfo("avg", "均值", "", "f2")},                                                                 
                {"difference", new IndexInfo("difference", "差异", "", "f2")},                                                                 
                {"diff", new IndexInfo("diff", "间隔天数", "", "")},                                                                 
                {"state", new IndexInfo("state", "状态", "", "")},                                                                 
                {"count", new IndexInfo("count", "总数", "", "")},                                                                 
                {"limit", new IndexInfo("limit", "涨停总数", "", "")},                                                                 
                {"percent", new IndexInfo("percent", "涨停比例", "", "f2")},                                                                 
                {"jgtime", new IndexInfo("jgtime", "间隔交易日", "", "")},                                                                 
                {"jgtimemax", new IndexInfo("jgtimemax", "最大涨停间隔", "", "")},                                                                 
                {"jgtimemin", new IndexInfo("jgtimemin", "最小涨停间隔", "", "")},                                                                 
                {"jgtimeave", new IndexInfo("jgtimeave", "平均涨停间隔", "", "")},                                                                 
                {"trade", new IndexInfo("trade", "交易总天数", "", "")},                                                                 
                {"per", new IndexInfo("per", "涨停比例", "", "f2")},                                                                 
                {"growthsz", new IndexInfo("growthsz","深圳主板涨幅大于2%", "", "")},                                                                 
                {"countsz", new IndexInfo("countsz","深圳主板总数", "", "")},                                                                 
                {"persz", new IndexInfo("persz","深圳主板百分比", "", "f2")},                                                                 
                {"growthsme", new IndexInfo("growthsme","深圳中小板涨幅大于2%", "", "")},                                                                 
                {"countsme", new IndexInfo("countsme","深圳中小板总数", "", "")},                                                                 
                {"persme", new IndexInfo("persme","深圳中小板百分比", "", "f2")},                                                                 
                {"growthgem", new IndexInfo("growthgem","创业板涨幅大于2%", "", "")},                                                                 
                {"countgem", new IndexInfo("countgem","创业板总数", "", "")},                                                                 
                {"pergem", new IndexInfo("pergem","创业板百分比", "", "f2")},                                                                 
                {"growthsh", new IndexInfo("growthsh","上海主板涨幅大于2%", "", "")},                                                                 
                {"countsh", new IndexInfo("countsh","上海主板总数", "", "")},                                                                 
                {"persh", new IndexInfo("persh","上海主板百分比", "", "f2")},                                                                 
                {"totalnum", new IndexInfo("totalnum","四个板块总数", "", "")},                                                                 
                {"growthnum", new IndexInfo("growthnum","四个板块总数量和中涨幅2%数量和", "", "f2")},                                                                 
                {"pertotalgrowth", new IndexInfo("pertotalgrowth","四个板块总数量和中涨幅2%数量和/四个板块总数量和", "", "f2")},                                                                 
                {"pertotalsz", new IndexInfo("pertotalsz","深圳主板总数量/四个板块总数量和", "", "f2")},                                                                 
                {"pertotalsme", new IndexInfo("pertotalsme","深圳中小板总数量/四个板块总数量和", "", "f2")},                                                                 
                {"pertotalgem", new IndexInfo("pertotalgem","创业板总数量/四个板块总数量和", "", "f2")},                                                                 
                {"pertotalsh", new IndexInfo("pertotalsh","上海主板总数量/四个板块总数量和", "", "f2")},                                                                 
                {"pergrowthsz", new IndexInfo("pergrowthsz","深圳主板涨幅大于2%/四个板块涨幅2%数量和", "", "f2")},                                                                 
                {"pergrowthsme", new IndexInfo("pergrowthsme","深圳中小板涨幅大于2%/四个板块涨幅2%数量和", "", "f2")},                                                                 
                {"pergrwothgem", new IndexInfo("pergrwothgem","创业板涨幅大于2%/四个板块涨幅2%数量和", "", "f2")},                                                                 
                {"pergrowthsh", new IndexInfo("pergrowthsh","上海主板涨幅大于2%/四个板块涨幅2%数量和", "", "f2")},   
                {"growth", new IndexInfo("growth","涨幅", "%", "f2")},   
                {"turn", new IndexInfo("turn","换手", "%", "f2")},   
                {"amp", new IndexInfo("amp","振幅", "%", "f2")},   
                {"total", new IndexInfo("total","总金额", "亿元", "f4")},   
                {"vol", new IndexInfo("vol","量比", "", "f2")}, 

            #endregion
        };
        
        public static string GetKeyByValue(Dictionary<string, string>dict, string value)
        {
            foreach (KeyValuePair<string, string> pair in dict)
            {
                if (pair.Value.Equals(value))
                {
                    return pair.Key;
                }
            }
            return "未知";
        }
    }
}
