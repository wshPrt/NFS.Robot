using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model
{
    public class RollerModel : INotifyPropertyChanged
    {
        public static RollerModel Instance = new RollerModel();

        private int[] _RollerNumber;
        private int[] _ErorrRollerNumber;
        private string[] _XSection;
        private int _TotalNumber;

        public int[] RollerNumber
        {
            get
            {
                return _RollerNumber;
            }
            set
            {
                _RollerNumber = value;
                OnPropertyChanged("RollerNumber");
            }
        }

        public int[] ErorrRollerNumber
        {
            get
            {
                return _ErorrRollerNumber;
            }
            set
            {
                _ErorrRollerNumber = value;
                OnPropertyChanged("ErorrRollerNumber");
            }
        }
        public string[] XSection
        {
            get
            {
                return _XSection;
            }
            set
            {
                _XSection = value;
                OnPropertyChanged("XSection");
            }
        }

        public int TotalNumber
        {
            get
            {
                return _TotalNumber;
            }
            set
            {
                _TotalNumber = value;
                OnPropertyChanged("TotalNumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
