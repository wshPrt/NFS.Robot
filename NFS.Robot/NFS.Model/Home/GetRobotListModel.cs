using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Home
{
    public class GetRobotListModel : BindableBase
    {
        /// <summary>
        /// ID
        /// </summary>
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 机器人编号
        /// </summary>
        private string robotNumber;
        public string RobotNumber
        {
            get { return robotNumber; }
            set { robotNumber = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 机器人名称
        /// </summary>
        private string robotName;
        public string RobotName
        {
            get { return robotName; }
            set { robotName = value; RaisePropertyChanged(); }
        }


        #region
        public class List
        {
            /// <summary>
            /// 机器人编号
            /// </summary>
            public string robot_code { get; set; }
            /// <summary>
            /// 机器人名称
            /// </summary>
            public string robot_name { get; set; }
            /// <summary>
            /// 机器人ID
            /// </summary>
            public int id { get; set; }
        }

        public class Root
        {
            /// <summary>
            ///  success
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 1表示PC端
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<List> list { get; set; }
        }

        #endregion

    }
}
