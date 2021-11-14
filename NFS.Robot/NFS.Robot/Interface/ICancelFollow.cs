using NFS.Commons;
using NFS.Commons.HttpRequest;
using NFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    /// <summary>
    /// 托辊运行列表
    /// </summary>
    public class IConveyorRollerList
    {
        /// <summary>
        /// 输送机分析-托辊运行列表
        /// </summary>
        /// <param name="line_id">线路ID</param>
        /// <param name="page">分页页码 第一页1，第二页2</param>
        /// <param name="page_size">每页数据行数 默认10行/1页</param>
        /// <returns></returns>
        public async Task<RollerRunListModel.Root> RollerRunList(int line_id, int page, int page_size)
        {
            var http = new HttpExtend();
            var result = await http.Post<dynamic, RollerRunListModel.Root>(Urls.ROLLER_RUN_LIST_URL + "?line_id=" + line_id + "&page=" + page + "&page_size=" + page_size, null);

            return result;
        }
    }
}
