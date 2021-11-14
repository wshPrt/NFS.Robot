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
    interface ISimplifyRobotListInterface
    {
        Task<SimplifyRobotListModel.Root> GetSimplifyRobotList(int line_id);
    }
}
