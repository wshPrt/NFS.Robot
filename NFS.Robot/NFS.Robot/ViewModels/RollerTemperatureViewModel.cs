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
    public class RollerTemperatureViewModel : BindableBase
    {
        private readonly IDialogHostService _dialogHost;
        public DelegateCommand OpenDetailCommand { get; private set; }//打开详情页
        public RollerTemperatureViewModel(IDialogHostService _dialogHost)
        {
            InitData();
            this._dialogHost = _dialogHost;
            OpenDetailCommand = new DelegateCommand(OpenDetail);

            #region 巡检线路、机器人下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            SimplifyRobot = new SimplifyRobotListModel();
            SimplifyRobotList = new ObservableCollection<SimplifyRobotListModel>();
            #endregion
            InitRollerHistogram();
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
            set
            {
                cmbSimplifyItem = value;
                if (value != null && value.LineId > 0)
                {
                    SimplifyRobotList.Clear();
                    InitSimplifyRobotList();
                }
            }
        }
        /// <summary>
        /// 获取机器人列表—精简
        /// </summary>
        private SimplifyRobotListModel _simplifyRobot;
        public SimplifyRobotListModel SimplifyRobot
        {
            get { return _simplifyRobot; }
            set { _simplifyRobot = value; }
        }
        private SimplifyRobotListModel cmbSimplifyRobotItem;
        public SimplifyRobotListModel CmbSimplifyRobotItem
        {
            get { return cmbSimplifyRobotItem; }
            set
            {
                cmbSimplifyRobotItem = value;
            }
        }
        private ObservableCollection<SimplifyRobotListModel> _simplifyRobotList;
        public ObservableCollection<SimplifyRobotListModel> SimplifyRobotList
        {
            get { return _simplifyRobotList; }
            set { _simplifyRobotList = value; }
        }
        /// <summary>
        /// 关注列表List
        /// </summary>
        private ObservableCollection<RollerTempModel> _rollerTempList;
        public ObservableCollection<RollerTempModel> RollerTempList
        {
            get { return _rollerTempList; }
            set
            {
                _rollerTempList = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 托辊测温- 关注/取消关注
        /// </summary>
        private DelegateCommand _followCommand;
        public DelegateCommand FollowCommand
        {
            get 
            {
                if (_followCommand == null)
                {
                    _followCommand = new DelegateCommand(() => InintFollowList());
                }
                return _followCommand; 
            }
            set { _followCommand = value; }
        }


        #endregion

        /// <summary>
        /// 加载关注列表
        /// </summary>
        private async void InitData()
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    RollerTempList = new ObservableCollection<RollerTempModel>()
                     {
                        new RollerTempModel()
                        {
                            RollerNumber = "R0001",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "超温",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        },
                         new RollerTempModel()
                        {
                            RollerNumber = "R0002",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "异响",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        },
                         new RollerTempModel()
                        {
                            RollerNumber = "R0003",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "磨损",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        },
                         new RollerTempModel()
                        {
                            RollerNumber = "R0004",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "脱落",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        },
                         new RollerTempModel()
                        {
                            RollerNumber = "R0005",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "其它",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        },
                         new RollerTempModel()
                        {
                            RollerNumber = "R0006",
                            Location ="二号线路150米处",
                            WarningNo = 3,
                            CurrentState = "异响",
                            LastTime ="2021-09-02 12:30",
                            LastTemp ="30℃",
                            MaximumTemp="90℃"
                        }
                     };
                }));
            });
        }

        private void OpenDetail() 
        {
            _dialogHost.ShowDialogAsync("RollerDetail", null);
        }

        /// <summary>
        /// 托辊测温-关注
        /// </summary>
        private async void InintFollowList() 
        {
            //await Task.Run(() =>
            //{
            //    int Count = ObSC_TempListModels.ToList().FindAll(p => p.IsSelected == true).Count;
            //    for (int i = 0; i < Count; i++)
            //    {
            //        var roller_Id = ObSC_TempListModels.ToList().FindAll(p => p.IsSelected == true)[i].Id;
            //        IFollow strFollow = new IFollow();
            //        var result = strFollow.Follow(roller_Id).Result;
            //        success = result.msg;

            //    }
            //    App.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        if (success == "关注成功")
            //        {
            //            RollerTempList.Clear();
            //            InintTemp();
            //        }
            //        else
            //        {
            //            MessageBox.Show(success);
            //        }
            //    }));
            //});
        }

        /// <summary>
        /// 托辊-柱状图
        /// </summary>
        private void InitRollerHistogram() 
        {

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

        /// <summary>
        /// 获取机器人列表(精简)
        /// </summary>
        private async void InitSimplifyRobotList()
        {
            await Task.Run(() =>
            {
                SimplifyRobotList simplifyRobot = new SimplifyRobotList();
                var result = simplifyRobot.GetSimplifyRobotList(CmbSimplifyItem.LineId).Result;
                string success = result.msg;
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    if (success == "读取成功")
                    {
                        for (int i = 0; i < result.data.Count; i++)
                        {
                            SimplifyRobotList.Add(new SimplifyRobotListModel()
                            {
                                RobotId = result.data[i].id,
                                RobotCode = result.data[i].robotCode,
                                RobotName = result.data[i].robotName
                            });
                        }
                    }
                }));
            });
        }
    }
}
