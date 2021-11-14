using NFS.Model.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Interface
{
   public interface ISignInterface
    {
        Task<LoginModel.root> AccountLogin(string userName, string passWord);
    }
}
