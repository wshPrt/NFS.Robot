using NFS.Model.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    interface IRobotOnlineListInterface
    {
        Task<RobotOnlineListModel.Root> GetRobotOnlineList(int onlineState);
    }
}
