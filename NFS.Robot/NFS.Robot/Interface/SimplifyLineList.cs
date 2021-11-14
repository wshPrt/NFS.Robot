using NFS.Commons;
using NFS.Commons.HttpRequest;
using NFS.Model.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    /// <summary>
    /// 获取线路列表—精简
    /// </summary>
    public class SimplifyLineList : ISimplifyLineListInterface
    {
        public async Task<SimplifyLineListModel.Root> GetLineList()
        {
            var http = new HttpExtend();

            var value = "304a99ac28cf10a8bc90e02bed23b3d7";
            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, SimplifyLineListModel.Root>(Urls.SIMPLIFY_GET_LINE_LIST_URL+ "?appkey=5272939369", null, headers); ;

            return result;
        }
    }
}
