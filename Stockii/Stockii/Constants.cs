﻿using System;
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

        public static Dictionary<string, string> tableNameDict = new Dictionary<string, string>{
                {"nDayCalTab","N日和"},
                {"customCalTab","自定义计算"}
        };

        public static Dictionary<string, string> nDayIndexDict = new Dictionary<string, string>{
                {"均价","avg_price"},
                {"涨幅","growth"},
                {"换手","turn"},
                {"振幅","amp"},
                {"总金额","total"},
                {"量比","vol"}
        };

        public static Dictionary<string, string> nDayTypeDict = new Dictionary<string, string>{
                {"正和","positive"},
                {"负和","negative"},
                {"所有和","all"}
        };

        public static Dictionary<string, string> customCalTypeDict = new Dictionary<string, string>{
                {"指定两天加","plus"},
                {"指定两天减","minus"},
                {"指定两天比值","divide"},
                {"指定时间段内最大值减最小值","maxmin"},
                {"指定时间段内最大值比最小值","maxmindivide"},
                {"指定时间段内的和","sum"},
                {"两个时间内涨幅,振幅数据分段","seperate"}
        };

        public static Dictionary<string, string> customCalIndexDict = new Dictionary<string, string>{
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
        };

        public static Dictionary<string, string> crossIndexDict = new Dictionary<string, string>{
                {"昨收","ytd_end_price"},
                {"均价","avg_price"}, 
                {"均价流通市值","avg_circulation_value"},
                {"总市值","total_value"},
                {"总股本","total_stock"},
                {"流通股本","cir_of_cap_stock"}
        };
        
        public static Dictionary<string, string> translateDict = new Dictionary<string, string>{
                {"stock_id", "代码"},
                {"stock_name", "名称"},
                {"stockname", "名称"},
                {"name", "名称"}, 
                {"created", "日期"},
                {"growth_ratio", "涨幅"},
                {"current_price", "现价"},
                {"daily_up_down", "日涨跌"},
                {"bought_price", "买入价"},
                {"sold_price", "卖出价"},
                {"total_deal_amount", "总量"},
                {"last_deal_amount", "现量"},
                {"growth_speed", "涨速"},
                {"turnover_ratio", "换手"},
                {"today_begin_price", "今开"},
                {"ytd_end_price", "昨收"},
                {"pe_ratio", "市盈率"},
                {"max", "最高"},
                {"min", "最低"},
                {"total_money", "总金额"},
                {"amplitude_ratio", "振幅"},
                {"cir_of_cap_stock", "流通股本"},
                {"upordown_per_deal", "笔涨跌"},
                {"volume_ratio", "量比"},
                {"avg_price", "均价"},
                {"DaPanWeiBi", "委比"},
                {"sell", "内盘"},
                {"buy", "外盘"},
                {"sb_ratio", "内外比"},
                {"DaPanWeiCha", "委量差"},
                {"num1_buy", "买量一"},
                {"num1_sell", "卖量一"},
                {"num1_buy_price", "买价一"},
                {"num1_sell_price", "卖价一"},
                {"num2_buy", "卖价二"},
                {"num2_sell", "卖量二"},
                {"num2_buy_price", "买价二"},
                {"num2_sell_price", "买量二"},
                {"num3_buy", "买价三"},
                {"num3_sell", "买量三"},
                {"num3_buy_price", "卖价三"},
                {"num3_sell_price", "卖量三"},
                {"circulation_value", "流通市值"},
                {"bbi_balance", "多空平衡"},
                {"bull_profit", "多头获利"},
                {"bull_stop_losses", "多头止损"},
                {"short_covering", "空头回补"},
                {"bear_stop_losses", "空头止损"},
                {"relative_strenth_index", "强弱度"},
                {"activity", "活跃度"},
                {"num_per_deal", "每笔均量"},
                {"turn_per_deal", "每笔换手"},
                {"update_date", "更新日期"},
                {"total_stock", "总股本"},
                {"max_circulation_value", "最高价流通市值"},
                {"current_circulation_value", "现价流通市值"},
                {"min_circulation_value", "最低价流通市值"},
                {"avg_circulation_value", "均价流通市值"},
                {"total_value", "总市值"}, 
                {"stockid", "代码"},  
                {"listdate", "日期"}, 
                {"onemonthsum", "1月和"}, 
                {"threesum", "3日和"},
                {"foursum", "4日和"},
                {"fivesum", "5日和"},
                {"sixsum", "6日和"},
                {"sevensum", "7日和"},
                {"eightsum", "8日和"},
                {"ninesum", "9日和"},
                {"tensum", "10日和"},
                {"elevensum", "11日和"},
                {"twelvesum", "12日和"},
                {"thirteensum", "13日和"},
                {"fourteensum", "14日和"},
                {"fifteensum", "15日和"},
                {"sixteensum", "16日和"},
                {"seventeensum", "17日和"},
                {"eighteensum", "18日和"},
                {"nineteensum", "19日和"},
                {"twentysum", "20日和"},
                {"twenty1sum", "21日和"},
                {"twenty2sum", "22日和"},
                {"twenty3sum", "23日和"},
                {"twenty4sum", "24日和"},
                {"twenty5sum", "25日和"},
                {"twenty6sum", "26日和"},
                {"twenty7sum", "27日和"},
                {"twenty8sum", "28日和"},
                {"twenty9sum", "29日和"},
                {"thirtysum", "30日和"},
                {"oneweeksum", "1周和"},
                {"twoweeksum", "2周和"},
                {"threeweeksum", "3周和"},
                {"fourweeksum", "4周和"},
                {"fiveweeksum", "5周和"},
                {"sixweeksum", "6周和"},
                {"growthcount", "涨幅总数"}, 
                {"ampcount", "振幅总数"}, 
                {"g0", "涨幅小于-9个数"},
                {"g1", "涨幅[-9~-8)个数"},
                {"g2", "涨幅[-8~-7)个数"},
                {"g3", "涨幅[-7~-6)个数"},
                {"g4", "涨幅[-6~-5)个数"},
                {"g5", "涨幅[-5~-4)个数"},
                {"g6", "涨幅[-4~-3)个数"},
                {"g7", "涨幅[-3~-2)个数"},
                {"g8", "涨幅[-2~-1)个数"},
                {"g9", "涨幅[-1~0)个数"},
                {"g10", "涨幅[0~1)个数"},
                {"g11", "涨幅[1~2)个数"},
                {"g12", "涨幅[2~3)个数"},
                {"g13", "涨幅[3~4)个数"},
                {"g14", "涨幅[4~5)个数"},
                {"g15", "涨幅[5~6)个数"},
                {"g16", "涨幅[6~7)个数"},
                {"g17", "涨幅[7~8)个数"},
                {"g18", "涨幅[8~9)个数"},
                {"g19", "涨幅大于9个数"},
                {"a0", "振幅[0~1)个数"},
                {"a1", "振幅[1~2)个数"},
                {"a2", "振幅[2~3)个数"},
                {"a3", "振幅[3~4)个数"},
                {"a4", "振幅[4~5)个数"},
                {"a5", "振幅[5~6)个数"},
                {"a6", "振幅[6~7)个数"},
                {"a7", "振幅[7~8)个数"},
                {"a8", "振幅[8~9)个数"},
                {"a9", "振幅[9~10)个数"},
                {"a10", "振幅[10~11)个数"},
                {"a11", "振幅[11~12)个数"},
                {"a12", "振幅[12~13)个数"},
                {"a13", "振幅[13~14)个数"},
                {"a14", "振幅[14~15)个数"},
                {"a15", "振幅[15~16)个数"},
                {"a16", "振幅[16~17)个数"},
                {"a17", "振幅[17~18)个数"},
                {"a18", "振幅[18~19)个数"},
                {"a19", "振幅大于19个数"},
                {"startvalue", "起始时间的值"}, 
                {"endvalue", "结束时间的值"}, 
                {"maxdate", "最大值日期"}, 
                {"mindate", "最小值日期"}, 
                {"maxvalue", "最大值"}, 
                {"minvalue", "最小值"}
        };
    }
}
