using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
    /// <summary>
    /// 获取机器人信息
    /// </summary>
    public class RobotInfoModel:BindableBase
    {
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
        /// <summary>
        /// 机器人mac地址
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
        /// 机器人编码
        /// </summary>
        private string _robotNumber;
        public string RobotNumber
        {
            get { return _robotNumber; }
            set 
            {
                _robotNumber = value;
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
        /// 是否在线， 1在线，0不在线
        /// </summary>
        private int _isOnLine;
        public int IsOnLine
        {
            get { return _isOnLine; }
            set
            {
                _isOnLine = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 速度(米/秒)
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
        /// 电力(100%)
        /// </summary>
        private int _battery;
        public int Battery
        {
            get { return _battery; }
            set 
            {
                _battery = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 续航里程(单位KM)
        /// </summary>
        private decimal _rechargeMileage;
        public decimal RechargeMileage
        {
            get { return _rechargeMileage; }
            set 
            {
                _rechargeMileage = value;
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
            /// 机器人 mac地址
            /// </summary>
            public string robotMac { get; set; }
            /// <summary>
            /// 机器人编码
            /// </summary>
            public string robotCode { get; set; }
            /// <summary>
            /// 机器人1号
            /// </summary>
            public string robotName { get; set; }
            /// <summary>
            /// 机器人状态，1可用，0不可用，2故障
            /// </summary>
            public int robotState { get; set; }
            /// <summary>
            /// 是否在线， 1在线，0不在线
            /// </summary>
            public int isOnline { get; set; }
            /// <summary>
            /// 速度(米/秒)
            /// </summary>
            public double speed { get; set; }
            /// <summary>
            /// //电力(100%)
            /// </summary>
            public int battery { get; set; }
            /// <summary>
            /// 续航里程(单位KM)
            /// </summary>
            public decimal endurance { get; set; }
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
            public Data data { get; set; }
        }

    }
}
