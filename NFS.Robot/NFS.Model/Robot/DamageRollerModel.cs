using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Robot
{
   public class DamageRollerModel : BindableBase
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
        /// 上次损坏时间
        /// </summary>
        private string _lastDamageTime;
        public string LastDamageTime
        {
            get { return _lastDamageTime; }
            set 
            {
                _lastDamageTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 上次损坏位置
        /// </summary>
        private string _lastDamagedLocation;
        public string LastDamagedLocation
        {
            get { return _lastDamagedLocation; }
            set 
            {
                _lastDamagedLocation = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 当前损坏次数
        /// </summary>
        private int _currentDamage;
        public int CurrentDamage
        {
            get { return _currentDamage; }
            set 
            {
                _currentDamage = value;
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

    }
}
