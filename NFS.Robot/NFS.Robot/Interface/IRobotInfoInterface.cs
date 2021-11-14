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
    interface IRobotInfoInterface
    {
        Task<RobotInfoModel.Root> GetLineList(int robot_id);
    }
}
