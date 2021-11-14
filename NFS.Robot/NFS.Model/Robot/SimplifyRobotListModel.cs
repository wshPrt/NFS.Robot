using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
    /// <summary>
    /// 获取机器人列表(精简)
    /// </summary>
    public class SimplifyRobotListModel :BindableBase
    {
        /// <summary>
        /// 机器人编码
        /// </summary>
        private string _robotCode;
        public string RobotCode
        {
            get { return _robotCode; }
            set
            {
                _robotCode = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 机器人名称
        /// </summary>
        private string _robotName;
        public string RobotName
        {
            get { return _robotName; }
            set
            {
                _robotName = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 机器人ID
        /// </summary>
        private int _robotId;
        public int RobotId
        {
            get { return _robotId; }
            set
            {
                _robotId = value;
                RaisePropertyChanged();
            }
        }


        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string robotCode { get; set; }
            /// <summary>
            /// 1号机器人
            /// </summary>
            public string robotName { get; set; }
            /// <summary>
            /// 机器人Id
            /// </summary>
            public int id { get; set; }
        }
        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Data> data { get; set; }
        }
    }
}
