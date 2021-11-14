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
    public class IRouteListForm
    {
        /// <summary>
        /// 路线列表For表单
        /// </summary>
        /// <returns></returns>
        public async Task<RouteFormModel.Root> RouteListForm()
        {
            var http = new HttpExtend();
            var result = await http.Post<dynamic, RouteFormModel.Root>(Urls.ROUTE_FORM_URL, null);

            return result;
        }
    }
}
