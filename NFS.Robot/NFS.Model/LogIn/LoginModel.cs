using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.LogIn
{
    public class LoginModel: BindableBase
    {
        /// <summary>
        /// 账号
        /// </summary>
        private string _account="songhu";
        public string Account
        {
            get { return _account; }
            set 
            {
                _account = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _pwd="123456";
        public string Pwd
        {
            get { return _pwd; }
            set 
            {
                _pwd = value;
                RaisePropertyChanged();
            }

        }

        /// <summary>
        /// 错误提示信息
        /// </summary>
        private string _warning;
        public string Warning
        {
            get { return _warning; }
            set 
            {
                _warning = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 用户名拼音
        /// </summary>
        private string _userNamePinyin;
        public string UserNamePinyin
        {
            get { return _userNamePinyin; }
            set
            {
                _userNamePinyin = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// 电话号码
        /// </summary>
        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set 
            {
                _telephone = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Token
        /// </summary>
        private string _token;
        public string Token
        {
            get { return _token; }
            set 
            {
                _token = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 监测标识编码
        /// </summary>
        private string _monitorCode;
        public string MonitorCode
        {
            get { return _monitorCode; }
            set 
            {
                _monitorCode = value;
                RaisePropertyChanged();
            }
        }




        public class root  
        {
            /// <summary>
            /// 读取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 编号
            /// </summary>
            public int code { get; set; }
            /// <summar ,    y>
            /// 用户信息
            /// </summary>
            public List<Login> Login { get; set; }
        }
        public class Login
        {
            ///// <summary>
            ///// token
            ///// </summary>
            //public string token { get; set; }
            ///// <summary>
            ///// 用户名中文
            ///// </summary>
            //public string realname { get; set; }
            ///// <summary>
            ///// / 内置头像 例如 12张， 从中选择1张即可
            ///// </summary>
            //public int avatar { get; set; }
            ///// <summary>
            ///// 用户名拼音
            ///// </summary>
            //public string username { get; set; }
            ///// <summary>
            ///// 电话号码
            ///// </summary>
            //public string phone { get; set; }
            ///// <summary>
            ///// 监控标识编码
            ///// </summary>
            //public string monitorCode { get; set; }


            /// <summary>
            /// 电话号码
            /// </summary>
            public string phone { get; set; }
            /// <summary>
            /// 监控标识编码
            /// </summary>
            public string monitorCode { get; set; }
            /// <summary>
            ///  内置头像 例如 12张， 从中选择1张即可
            /// </summary>
            public int avatar { get; set; }
            /// <summary>
            /// 监控线路
            /// </summary>
            public string monitorLine { get; set; }
            /// <summary>
            /// token
            /// </summary>
            public string token { get; set; }
            /// <summary>
            /// 用户名中文
            /// </summary>
            public string realname { get; set; }
        }
    }
}
