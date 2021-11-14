using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Conveyor
{
    /// <summary>
    /// 输送机维修记录
    /// </summary>
   public class MaintainRecordModel : BindableBase
    {

        /// <summary>
        /// 报修单号
        /// </summary>
        private string _singleNumber;
        public string SingleNumber
        {
            get { return _singleNumber; }
            set 
            {
                _singleNumber = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        private string _deviceName;
        public string DeviceName
        {
            get { return _deviceName; }
            set 
            {
                _deviceName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 设备位置
        /// </summary>
        private string _deviceLocation;
        public string DeviceLocation
        {
            get { return _deviceLocation; }
            set 
            {
                _deviceLocation = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 报修时间
        /// </summary>
        private string _repairTime;
        public string RepairTime
        {
            get { return _repairTime; }
            set 
            {
                _repairTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 故障描述
        /// </summary>
        private string _faultDescribe;
        public string FaultDescribe
        {
            get { return _faultDescribe; }
            set 
            {
                _faultDescribe = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        private string _currentState;
        public string CurrentState
        {
            get { return _currentState; }
            set 
            {
                _currentState = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 预计维修时间
        /// </summary>
        private string _expectedMaintainTime;
        public string ExpectedMaintainTime
        {
            get { return _expectedMaintainTime; }
            set 
            {
                _expectedMaintainTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        private string _completeTime;
        public string CompleteTime
        {
            get { return _completeTime; }
            set 
            {
                _completeTime = value;
                RaisePropertyChanged();
            }
        }


    }
}
