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
    /// 获取线路列表—普通
    /// </summary>
    public class OrdinaryLineList : ILineListInterface
    {
        public async Task<OrdinaryLineListModel.Root> GetLineList()
        {
            var http = new HttpExtend();
            var value = "7c24156b4d7c7542f26d39bb9e7ab857";
            var headers = new Dictionary<string, string>();
            headers.Add("token", value);
            var result = await http.Post<dynamic, OrdinaryLineListModel.Root>(Urls.ORDINARY_GET_LINE_LIST_URL+ "?appkey=5272939369", null, headers);

            return result;
        }
    }
}
