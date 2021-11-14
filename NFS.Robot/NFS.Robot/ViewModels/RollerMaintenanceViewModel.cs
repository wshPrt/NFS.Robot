using NFS.Model.Robot;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
    public class RollerMaintenanceViewModel : BindableBase,IDialogAware
    {
        public string Title { get; set; }
        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog()
        {
            return true;
        }
        public RollerMaintenanceViewModel() 
        {
            InitData();
        }

        /// <summary>
        /// 重点关注托辊List
        /// </summary>
        private ObservableCollection<DamageRollerModel> _damageRollerList;
        public ObservableCollection<DamageRollerModel> DamageRollerList
        {
            get { return _damageRollerList; }
            set 
            {
                _damageRollerList = value;
                RaisePropertyChanged();
            }
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        private async void InitData() 
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    DamageRollerList = new ObservableCollection<DamageRollerModel>()
                     {
                        new DamageRollerModel()
                        {
                          RollerNumber="R00001",
                          LastDamagedLocation = "300m处",
                          LastDamageTime="2021-09-17",
                          CurrentDamage=3,
                          CurrentState="超温"
                        },
                         new DamageRollerModel()
                        {
                          RollerNumber="R00002",
                          LastDamagedLocation = "300m处",
                          LastDamageTime="",
                          CurrentDamage=0,
                          CurrentState="脱落"
                        },
                         new DamageRollerModel()
                        {
                          RollerNumber="R00003",
                          LastDamagedLocation = "300m处",
                          LastDamageTime="",
                          CurrentDamage=0,
                          CurrentState="磨损"
                        },
                         new DamageRollerModel()
                        {
                          RollerNumber="R00004",
                          LastDamagedLocation = "300m处",
                          LastDamageTime="",
                          CurrentDamage=0,
                          CurrentState="异响"
                        },
                         new DamageRollerModel()
                        {
                          RollerNumber="R00005",
                          LastDamagedLocation = "300m处",
                          LastDamageTime="",
                          CurrentDamage=0,
                          CurrentState="异响"
                        },
                     };
                }));
            });
        }
    }
}
