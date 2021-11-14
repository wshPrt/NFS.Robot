using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
   public class RollerDetailModel:BindableBase
    {
        /// <summary>
        /// 日期
        /// </summary>
        private string _date;
        public string Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最高温度
        /// </summary>
        private string _highestTemperature;
        public string HighestTemperature
        {
            get { return _highestTemperature; }
            set
            {
                _highestTemperature = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最低温度
        /// </summary>
        private string _lowestTemperature;
        public string LowestTemperature
        {
            get { return _lowestTemperature; }
            set 
            {
                _lowestTemperature = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 测温次数
        /// </summary>
        private int _count;
        public int Count
        {
            get { return _count; }
            set 
            {
                _count = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 平均温度
        /// </summary>
        private string _average;
        public string Average
        {
            get { return _average; }
            set 
            {
                _average = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最后测温时间
        /// </summary>
        private string _lastTemperatureTime;
        public string LastTemperatureTime
        {
            get { return _lastTemperatureTime; }
            set 
            {
                _lastTemperatureTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最后测温温度
        /// </summary>
        private string _lastTemperature;
        public string LastTemperature
        {
            get { return _lastTemperature; }
            set 
            {
                _lastTemperature = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 当天状态
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
    }
}
