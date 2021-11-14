using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Conveyor
{
  public class AlarmRankingModel: BindableBase
    {
        /// <summary>
        /// 排名
        /// </summary>
        private string _rank;
        public string Rank 
        {
            get { return _rank; }
            set 
            {
                _rank = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 告警因子
        /// </summary>
        private string _AlertFactor;
        public string AlertFactor
        {
            get { return _AlertFactor; }
            set 
            {
                _AlertFactor = value;
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
        /// 告警数
        /// </summary>
        private int _alarmsNumber;
        public int AlarmsNumber
        {
            get { return _alarmsNumber; }
            set 
            {
                _alarmsNumber = value;
                RaisePropertyChanged();
            }
        }


    }
}
