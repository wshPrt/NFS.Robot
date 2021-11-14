using NFS.Model.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
    interface ILineListInterface
    {
        Task<OrdinaryLineListModel.Root> GetLineList();
    }
}
