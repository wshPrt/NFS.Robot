using NFS.Commons;
using NFS.Commons.HttpRequest;
using NFS.Model.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    /// <summary>
    /// 获取机器人在线列表
    /// </summary>
    public class RobotOnlineList : IRobotOnlineListInterface
    {
        public async Task<RobotOnlineListModel.Root> GetRobotOnlineList(int onlineState)
        {
            var http = new HttpExtend();
            var value = "7c24156b4d7c7542f26d39bb9e7ab857";
            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, RobotOnlineListModel.Root>(Urls.GET_ONLINE_LIST_ROBOTS_URL + "?appkey=5272939369"+"&is_online=" + onlineState , null, headers); ;

            return result;
        }
    }
}
