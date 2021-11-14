using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
   public class RollerTempModel: BindableBase
    {
        /// <summary>
        /// 托辊编号
        /// </summary>
        private string _rollerNumber;
        public string RollerNumber
        {
            get { return _rollerNumber; }
            set
            {
                _rollerNumber = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 位置
        /// </summary>
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 历史告警次数
        /// </summary>
        private int _warningNo;
        public int WarningNo 
        {
            get { return _warningNo; }
            set 
            { 
                _warningNo = value;
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
        /// 最后测温时间
        /// </summary>
        private string _lastTime;
        public string LastTime
        {
            get { return _lastTime; }
            set 
            {
                _lastTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最后测温温度
        /// </summary>
        private string _lastTemp;
        public string LastTemp
        {
            get { return _lastTemp; }
            set 
            { 
                _lastTemp = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 历史最高温度
        /// </summary>
        private string _maximumTemp;
        public string MaximumTemp
        {
            get { return _maximumTemp; }
            set 
            {
                _maximumTemp = value;
                RaisePropertyChanged();
            }
        }
    }
}
