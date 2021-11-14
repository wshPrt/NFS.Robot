using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Conveyor
{
    /// <summary>
    /// 环境数据分析-历史告警
    /// </summary>
    public class EnvironmentalWarningModel: BindableBase
    {
        /// <summary>
        /// 告警时间
        /// </summary>
        private string _warningTime;
        public string WarningTime
        {
            get { return _warningTime; }
            set 
            {
                _warningTime = value;
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
        /// 告警因子
        /// </summary>
        private string _alertFactor ;
        public string AlertFactor
        {
            get { return _alertFactor; }
            set 
            {
                _alertFactor  = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 告警数值
        /// </summary>
        private string _alarmValue;
        public string AlarmValue
        {
            get { return _alarmValue; }
            set 
            {
                _alarmValue = value;
                RaisePropertyChanged();
            }
        }

    }
}
