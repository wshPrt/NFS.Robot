using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.DataCenter
{
   public class UserManage: BindableBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        private int _serialNumber;
        public int SerialNumber
        {
            get { return _serialNumber; }
            set 
            {
                _serialNumber = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        private string _userPower;
        public string UserPower
        {
            get { return _userPower; }
            set
            {
                _userPower = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _passWord;
        public string PassWord 
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                RaisePropertyChanged();
            }
        }
    }
}
