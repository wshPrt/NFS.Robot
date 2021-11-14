using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Line
{
    /// <summary>
    /// 获取线路列表(普通的)
    /// </summary>
    public class OrdinaryLineListModel : BindableBase
    {
        /// <summary>
        /// 线路ID
        /// </summary>
        private int _lineId;
        public int LineId
        {
            get { return _lineId; }
            set
            {
                _lineId = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 线路名称
        /// </summary>
        private string _lineName;
        public string LineName
        {
            get { return _lineName; }
            set
            {
                _lineName = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 告警状态
        /// </summary>
        private int _alarmState;
        public int AlarmState
        {
            get { return _alarmState; }
            set
            {
                _alarmState = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 告警内容
        /// </summary>
        private string _alarmContent;
        public string AlarmContent
        {
            get { return _alarmContent; }
            set
            {
                _alarmContent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 坐标
        /// </summary>
        private string _coordinates;
        public string Coordinates
        {
            get { return _coordinates; }
            set
            {
                _coordinates = value;
                RaisePropertyChanged();
            }
        }




        public class Data
        {
            /// <summary>
            /// 线路id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 线路名称
            /// </summary>
            public string lineName { get; set; }
            /// <summary>
            /// 告警状态， 1正常， 2 告警
            /// </summary>
            public int lineAlarmState { get; set; }
            /// <summary>
            /// 告警内容
            /// </summary>
            public string lineAlarmName { get; set; }
            /// <summary>
            /// 线路坐标
            /// </summary>
            public string linePointer { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 读取成功
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
