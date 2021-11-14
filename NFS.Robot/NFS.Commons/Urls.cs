using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Commons
{
    public class Urls
    {
        /// <summary>
        /// 前可见光
        /// </summary>
        public static  string FRONT_LIGHT_URL = "rtmp://192.168.100.201:1935/live/farward";
        /// <summary>
        /// 红外
        /// </summary>
        public static  string INFRARED_URL = "rtmp://192.168.100.201:1935/live/iray";
        /// <summary>
        /// 右边回程视频
        /// </summary>
        public static string RETURN_TRIP = "rtmp://192.168.100.201:1935/live/";
        /// <summary>
        /// 请求IP地址
        /// ConfigurationManager.ConnectionStrings["SERVER_URL"].ConnectionString;
        /// "http://api.cqbaoli.net";
        /// </summary>
        private static readonly string SERVER_URL = "http://121.196.123.245:8080";
        /// <summary>
        /// 视频流地址
        /// //ConfigurationManager.ConnectionStrings["RTSP_URL"].ConnectionString;
        /// </summary>
        public static readonly string RTSP_URL = "rtsp://192.168.100.134/live/test";
        //public static readonly string RTSP_URL = "rtsp://121.196.123.245/live/test";
        /// <summary>
        /// 音频流地址
        /// </summary>
        public static string AUDIO_RTSP_URL = "rtmp://121.196.123.245:19351/live/test1";
        /// <summary>
        /// 登录
        /// </summary>
        public static string LOGIN_URL = SERVER_URL + "/api-pc/auth/login?appkey=5272939369?token=7c24156b4d7c7542f26d39bb9e7ab857";
        /// <summary>
        /// 获取线路列表—普通
        /// </summary>
        public static string ORDINARY_GET_LINE_LIST_URL = SERVER_URL + "/api-pc/line/get-line-list";
        /// <summary>
        /// 获取线路列表—精简
        /// </summary>
        public static string SIMPLIFY_GET_LINE_LIST_URL = SERVER_URL + "/api-pc/line/get-line-list-pithy";
        /// <summary>
        /// 获取机器人列表(根据路线ID获取机器人列表)
        /// </summary>
        public static string SIMPLIFY_GET_THE_LIST_ROBOTS_URL = SERVER_URL + "/api-pc/robot/get-robot-list-pithy";
        /// <summary>
        /// 获取机器人信息
        /// </summary>
        public static string GET_ROBOT_INFORMATION_URL = SERVER_URL + "/api-pc/robot/get-robot-info";
        /// <summary>
        ///获取机器人在线列表
        /// </summary>
        public static string GET_ONLINE_LIST_ROBOTS_URL = SERVER_URL + "/api-pc/robot/get-robot-online-list";



        /// <summary>
        /// 首页
        /// </summary>
        public static string HOME_URL = SERVER_URL + "/Service/Home";
        /// <summary>
        /// 获取最新版本
        /// </summary>
        public static string VERSION_URL = SERVER_URL + "/Service/Utility.svc/Version";
        /// <summary>
        /// 线路列表
        /// </summary>
        public static string ROUTE_URL = SERVER_URL + "/api/line/getMonitorLineList";
        /// <summary>
        /// 路线列表For表单
        /// </summary>
        public static string ROUTE_FORM_URL = SERVER_URL + "/api/line/getLineListForForm";
        /// <summary>
        /// 根据路线ID获取机器人列表
        /// </summary>
        public static string GET_ROBOT_LIST_URL = SERVER_URL + "/api/robot/getRobotListByLine";
        /// <summary>
        /// 巡检策略设置
        /// </summary>
        public static string POLICY_SETTING_URL = SERVER_URL + "/api/robot/pushMonitorStrategySetting";
        /// <summary>
        /// 根据路线获取托辊列表
        /// </summary>
        public static string GET_ROLLER_LIST_URL = SERVER_URL + "/api/roller/getRollerListByLine";
        /// <summary>
        /// 托辊测温-统计分析
        /// </summary>
        public static string ROLLER_ANALYSIS_URL = SERVER_URL + "/api/roller/getLineRollerAnalysis";
        /// <summary>
        /// 托辊测温-托辊温度数据列表
        /// </summary>
        public static string TEMP_LIST_URL = SERVER_URL + "/api/roller/getLineRollerTempDataList";
        /// <summary>
        /// 托辊测温-关注
        /// </summary>
        public static string ROLLER_FOLLOW_URL = SERVER_URL + "/api/roller/rollerFollow";
        /// <summary>
        /// 托辊测温-取消关注
        /// </summary>
        public static string ROLLER_CANCEL_FOLLOW_URL = SERVER_URL + "/api/roller/rollerUnFollow";

        /// <summary>
        /// 托辊测温-托辊温度报表
        /// </summary>
        public static string ROLLER_TEMP_REPORT_URL = SERVER_URL + "/api/roller/getLineRollerTempReportDataList";
        /// <summary>
        /// 托辊测温详情-历史统计
        /// </summary>
        public static string ROLLER_DETAILS_ANALYSIS_URL = SERVER_URL + "/api/roller/getRollerTempAnalysisInfo";
        /// <summary>
        /// 托辊测温详情-历史温度列表
        /// </summary>
        public static string ROLLER_DETAILS_TEMP_LIST_URL = SERVER_URL + "/api/roller/getRollerHistoryTempDataList";
        /// <summary>
        /// 托辊测温详情-历史温度图表
        /// </summary>
        public static string ROLLER_DETAILS_TEMP_CHART_URL = SERVER_URL + "/api/roller/getRollerHistoryTempReport";


        /// <summary>
        /// 环境数据-环境温度
        /// </summary>
        public static string ENVIRONMENT_TEMP_URL = SERVER_URL + "/api/env/getEnvTempDataInfo";
        /// <summary>
        /// 环境数据-环境湿度
        /// </summary>
        public static string ENVIRONMENT_HUMIDITY_URL = SERVER_URL + "/api/env/getEnvHumidityDataInfo";
        /// <summary>
        /// 环境数据-环境粉尘
        /// </summary>
        public static string ENVIRONMENT_DUST_URL = SERVER_URL + "/api/env/getEnvDustDataInfo";
        /// <summary>
        /// 环境数据-环境CO浓度
        /// </summary>
        public static string ENVIRONMENT_CONCENTRATION_URL = SERVER_URL + "/api/env/getEnvCODataInfo";
        /// <summary>
        /// 环境数据-环境噪声
        /// </summary>
        public static string ENVIRONMENT_NOISE_URL = SERVER_URL + "/api/env/getEnvNoiseDataInfo";
        /// <summary>
        /// 输送机分析-输送机信息
        /// </summary>
        public static string CONVEYOR_INFO_URL = SERVER_URL + "/api/device/getConveyorInfo";
        /// <summary>
        /// 输送机分析-托辊运行列表
        /// </summary>
        public static string ROLLER_RUN_LIST_URL = SERVER_URL + "/api/roller/getRollerRunInfoDataList";
        /// <summary>
        /// 维修建议
        /// </summary>
        public static string REPAIR_PROPOSAL_URL = SERVER_URL + "/api/roller/getFixSuggest";
        /// <summary>
        /// 输送机分析-托辊分析-统计
        /// </summary>
        public static string ROLLER_ANALYSIS_STATISTICS_URL = SERVER_URL + "/api/roller/getRollerAnalyseInfo";
        /// <summary>
        /// 输送机分析-托辊分析-异常数量趋势分析
        /// </summary>
        public static string ERROR_NUMBER_TREND_ANALYSIS_URL = SERVER_URL + "/api/roller/getAbnormalMonthReportList";

        /// <summary>
        /// 托辊分析 - 高频损坏托辊列表
        /// </summary>
        public static string HIGH_DAMAGE_ROLLER_LIST_URL = SERVER_URL + "/api/roller/getHighBrokenRollerList";
        /// <summary>
        /// 托辊分析-饼图
        /// </summary>
        public static string ROLLER_ANALYSIS_CHART_URL = SERVER_URL + "/api/roller/getAbnormalTypeDataForPicReport";
        /// <summary>
        /// 环境数据分析- 噪声强度历史数据
        /// </summary>
        public static string NOISE_INTENSITY_HISTORY_URL = SERVER_URL + "/api/env/getEnvNoiseHistoryLineReport";
        /// <summary>
        /// 环境数据分析- 震动幅度历史数据
        /// </summary>
        public static string VIBRATION_AMPLITUDE_HISTORY_URL = SERVER_URL + "/api/env/getEnvAmplitudeHistoryLineReport";
        /// <summary>
        /// 环境数据分析- 粉尘浓度历史数据
        /// </summary>
        public static string DUST_CONCENTRATION_HISTORY_URL = SERVER_URL + "/api/env/getEnvDustHistoryLineReport";


        /// <summary>
        /// 托辊分析- 托辊区段分析
        /// </summary>
        public static string DUST_IDLER_SECTION_URL = SERVER_URL + "/api/roller/getRollerSectionReportList";
        /// <summary>
        /// 设备告警历史记录
        /// </summary>
        public static string FACILITY_WARNING_URL = SERVER_URL + "/api/device/getDeviceAlarmHistoryDataList";
    }
}
