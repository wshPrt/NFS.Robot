using NFS.Model.Conveyor;
using NFS.Model.Home;
using NFS.Model.Line;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using NFS.Robot.Resource.Dialog;
using Prism.Commands;
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
   public class MaintainRecordViewModel: BindableBase
    {
        private readonly IDialogHostService _dialogHost;
        private readonly IRegionManager regiomManager;
        public DelegateCommand AddRecordCommand { get; private set; }//打开添加记录页指令
        public DelegateCommand MaintainDetailsCommand { get; private set; }//打开维修记录详情页指令
        public MaintainRecordViewModel(IRegionManager regiomManager, IDialogHostService dialogHost) 
        {
            this.regiomManager = regiomManager;
            this._dialogHost = dialogHost;

            AddRecordCommand = new DelegateCommand(AddRecord);
            MaintainDetailsCommand = new DelegateCommand(MaintainDetails);
            InitMaintainRecord();

            #region 巡检线路、机器人下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            #endregion
        }

        #region 属性
        private ObservableCollection<MaintainRecordModel> _maintainRecordList;
        public ObservableCollection<MaintainRecordModel> MaintainRecordList
        {
            get { return _maintainRecordList; }
            set
            {
                _maintainRecordList = value;
                RaisePropertyChanged();
            }
        }
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
            set { cmbSimplifyItem = value; RaisePropertyChanged(); }
        }
        #endregion

        /// <summary>
        /// 打开添加记录页
        /// </summary>
        private void AddRecord() 
        {
            _dialogHost.ShowDialogAsync("AddRecord", null);
        }

        /// <summary>
        /// 打开维修记录详情页
        /// </summary>
        private void MaintainDetails() 
        {
            _dialogHost.ShowDialogAsync("MaintainDetails", null);
        }

        /// <summary>
        /// 加载输送维修记录
        /// </summary>
        private async void InitMaintainRecord() 
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    MaintainRecordList = new ObservableCollection<MaintainRecordModel>()
                     {
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="托辊",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="机架",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="输送带",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="传动滚筒",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="改下滚筒",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="驱动装置",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="托辊抽承",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        },
                        new MaintainRecordModel()
                        {
                            SingleNumber="wx20210926133217",
                            DeviceName="地脚螺栓",
                            DeviceLocation="一号线路150m处",
                            RepairTime ="2021-09-18",
                            FaultDescribe ="超温需要更换.....",
                            CurrentState="待维修",
                            ExpectedMaintainTime ="2021-09-19",
                            CompleteTime="2021-09-19"
                        }
                     };
                }));
            });
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
