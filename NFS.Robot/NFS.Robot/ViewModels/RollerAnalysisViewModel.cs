using NFS.Model.Home;
using NFS.Model.Line;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using NFS.Robot.Resource.Dialog;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.ViewModels
{
    public class RollerAnalysisViewModel : BindableBase
    {
        private readonly IDialogHostService _dialogHost;
        private readonly IRegionManager regiomManager;
        public DelegateCommand RollerRemarksCommand { get; private set; }
        public DelegateCommand RollerRemarkDetailsCommand { get; private set; }
        public RollerAnalysisViewModel(IRegionManager regiomManager, IDialogHostService dialogHost)
        {
            this.regiomManager = regiomManager;
            this._dialogHost = dialogHost;

            InitData();
            RollerRemarksCommand = new DelegateCommand(RollerRemarks);
            RollerRemarkDetailsCommand = new DelegateCommand(RollerRemarkDetails);

            #region 巡检线路下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            #endregion

        }

        #region 属性
        /// <summary>
        /// 获取线路列表—精简
        /// </summary>
        private SimplifyLineListModel _simplifyLine;
        public SimplifyLineListModel SimplifyLine
        {
            get { return _simplifyLine; }
            set { _simplifyLine = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<SimplifyLineListModel> _simplifyLineList;
        public ObservableCollection<SimplifyLineListModel> SimplifyLineList
        {
            get { return _simplifyLineList; }
            set { _simplifyLineList = value; RaisePropertyChanged(); }
        }
        private SimplifyLineListModel cmbSimplifyItem;
        public SimplifyLineListModel CmbSimplifyItem
        {
            get { return cmbSimplifyItem; }
            set{ cmbSimplifyItem = value; }
        }
        /// <summary>
        /// 高频损坏托辊List
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
        #endregion

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
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00002",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00003",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00004",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00005",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00006",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00007",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        },
                        new DamageRollerModel()
                        {
                            RollerNumber="R00008",
                            LastDamageTime="2021-09-18 11:57:00",
                            LastDamagedLocation="一号线路150m处",
                            CurrentDamage =3,
                            CurrentState="超温"
                        }
                     };
                }));
            });
        }

        private void RollerRemarks()
        {
            _dialogHost.ShowDialogAsync("RollerRemarks", null);
        }

        public void RollerRemarkDetails() 
        {
            _dialogHost.ShowDialogAsync("RollerRemarkDetails", null);
        }

        /// <summary>
        /// 获取线路列表(精简)
        /// </summary>
        private async void InitLineList()
        {
            await Task.Run(() =>
            {
                SimplifyLineList simplify = new SimplifyLineList();
                var result = simplify.GetLineList().Result;
                string success = result.msg;
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (success == "读取成功")
                    {
                        for (int i = 0; i < result.data.Count; i++)
                        {
                            SimplifyLineList.Add(new SimplifyLineListModel()
                            {
                                LineId = result.data[i].id,
                                LineName = result.data[i].lineName
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show(success);
                    }
                }));
            });
        }

    }
}
