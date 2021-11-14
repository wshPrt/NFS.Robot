using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Conveyor
{
   public class HistoryAlertModel: BindableBase
    {

        /// <summary>
        /// 警告时间
        /// </summary>
        private string _alertTime;
        public string AlertTime
        {
            get { return _alertTime; }
            set 
            {
                _alertTime = value;
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

        private string _alertType;
        public string AlertType 
        {
            get { return _alertType; }
            set 
            {
                _alertType = value;
                RaisePropertyChanged();
            }
        }

    }
}
