using NFS.Commons;
using NFS.Commons.HttpRequest;
using NFS.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    /// <summary>
    /// 根据路线ID获取机器人列表
    /// </summary>
    public class IGetListRobots
    {
        /// <summary>
        /// 根据路线ID获取机器人列表
        /// </summary>
        /// <param name="line_id">线路ID</param>
        /// <returns></returns>
        public async Task<GetRobotListModel.Root> QueryRoutes(int? line_id)
        {
            //Dictionary<string, Object> dic = new Dictionary<string, object>();
            //dic.Add("line_id", line_id);

            var http = new HttpExtend();
            var result = await http.Post<dynamic, GetRobotListModel.Root>(Urls.GET_ROBOT_LIST_URL + "?line_id=" + line_id, null);

            return result;
        }
    }
}
