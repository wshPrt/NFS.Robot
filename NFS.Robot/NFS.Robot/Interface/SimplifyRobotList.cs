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
    /// 获取机器人列表—精简
    /// </summary>
    public class SimplifyRobotList : ISimplifyRobotListInterface
    {
        public async Task<SimplifyRobotListModel.Root> GetSimplifyRobotList(int line_id)
        {
            var http = new HttpExtend();
            var value = "1831537678d57782c2b0cd184e0b3657";
            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, SimplifyRobotListModel.Root>(Urls.SIMPLIFY_GET_THE_LIST_ROBOTS_URL+ "?appkey=5272939369"+ "&line_id=" + line_id, null, headers); ;

            return result;
        }
    }
}
