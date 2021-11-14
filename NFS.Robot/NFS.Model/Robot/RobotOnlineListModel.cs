using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
    /// <summary>
    /// 机器人在线列表
    /// </summary>
    public class RobotOnlineListModel:BindableBase
    {
        /// <summary>
        /// 机器人Id
        /// </summary>
        private int robotId;
        public int RobotId
        {
            get { return robotId; }
            set 
            {
                robotId = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 机器MAC地址
        /// </summary>
        private string _robotMacAddress;
        public string RobotMacAddress
        {
            get { return _robotMacAddress; }
            set 
            {
                _robotMacAddress = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 机器人编号
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
        /// 机器人状态
        /// </summary>
        private int _robotState;
        public int RobotState
        {
            get { return _robotState; }
            set
            {
                _robotState = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 机器人状态 1可用，0不可用，2故障
        /// </summary>
        private int _workState;
        public int WorkState
        {
            get { return _workState; }
            set 
            {
                _workState = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  是否在线  1：在线，0：离线
        /// </summary>
        private int _isOnline;
        public int IsOnline
        {
            get { return _isOnline; }
            set 
            { 
                _isOnline = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 速度(km)
        /// </summary>
        private decimal _speed;
        public decimal Speed
        {
            get { return _speed; }
            set 
            {
                _speed = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 电量
        /// </summary>
        private string _battery;
        public string Battery
        {
            get { return _battery; }
            set 
            {
                _battery = value;
                RaisePropertyChanged();
            }
        }
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




        public class Data
        {
            /// <summary>
            /// 机器人ID
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 机器mac地址
            /// </summary>
            public string robotMac { get; set; }
            /// <summary>
            /// 机器人编码
            /// </summary>
            public string robotCode { get; set; }
            /// <summary>
            /// 机器人名称，默认与机器人编码一致（如果为null 则显示机器人编码）
            /// </summary>
            public string robotName { get; set; }
            /// <summary>
            /// 机器人状态 1可用，0不可用，2故障
            /// </summary>
            public int robotState { get; set; }
            /// <summary>
            /// 工作状态，1 充电中，2待命中，3巡检中，4已关机
            /// </summary>
            public int workState { get; set; }
            /// <summary>
            /// 是否在线  1：在线，0：离线
            /// </summary>
            public int isOnline { get; set; }
            /// <summary>
            /// 速度
            /// </summary>
            public double speed { get; set; }
            /// <summary>
            /// 电量
            /// </summary>
            public int battery { get; set; }
            /// <summary>
            /// 线路ID
            /// </summary>
            public int lineId { get; set; }
            /// <summary>
            /// 线路名称
            /// </summary>
            public string lineName { get; set; }
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
