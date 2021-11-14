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
    /// 获取机器人信息
    /// </summary>
    public class GetRobotInfo : IRobotInfoInterface
    {
        public async Task<RobotInfoModel.Root> GetLineList(int robot_id)
        {
            var http = new HttpExtend();
            var value = "1831537678d57782c2b0cd184e0b3657";
            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, RobotInfoModel.Root>(Urls.GET_ROBOT_INFORMATION_URL+ "?appkey=5272939369"+ "&robot_id=" + robot_id, null,headers);
            return result;
        }
    }
}
