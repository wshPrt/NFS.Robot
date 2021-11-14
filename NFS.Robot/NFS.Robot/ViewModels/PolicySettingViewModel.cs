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
    public class PolicySettingViewModel : BindableBase
    {
        //private readonly IDialogService dialog;
        private readonly IDialogHostService _dialogHost;
        private readonly IRegionManager regiomManager;
        public DelegateCommand OpenCommand { get; private set; }//打开添加巡检策略指令
        public DelegateCommand EditCommand { get; private set; }//修改巡检策略指令
        public DelegateCommand DelCommmand { get; private set; }//打开删除提示框
        public PolicySettingViewModel(IRegionManager regiomManager, IDialogHostService dialogHost)
        {
            this.regiomManager = regiomManager;
            this._dialogHost = dialogHost;

            TacticsList = new ObservableCollection<TacticsSettingsModel>();
            InitData();
            OpenCommand = new DelegateCommand(Open);
            EditCommand = new DelegateCommand(Add);
            DelCommmand = new DelegateCommand(Del);

            #region 巡检线路、机器人下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            SimplifyRobot = new SimplifyRobotListModel();
            SimplifyRobotList = new ObservableCollection<SimplifyRobotListModel>();
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
        /// <summary>
        /// 获取机器人列表—精简
        /// </summary>
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
        #endregion

        /// <summary>
        /// 策略设置List
        /// </summary>
        private ObservableCollection<TacticsSettingsModel> _tacticsList;

        //public event Action<IDialogResult> RequestClose;

        public ObservableCollection<TacticsSettingsModel> TacticsList
        {
            get { return _tacticsList; }
            set
            {
                _tacticsList = value;
                RaisePropertyChanged();
            }
        }

        public string Title => throw new NotImplementedException();

        /// <summary>
        /// 弹出修改策略设置页
        /// </summary>
        private void Open()
        {
            //DialogParameters param = new DialogParameters();
            //param.Add("Value", "Hello~");
            //_dialogHost.ShowDialog("AddTactics",param,arg=> 
            //{
            //    if (arg.Result == ButtonResult.OK)
            //    {
            //        arg.Parameters.GetValue<string>("Value");
            //    }
            //});

             _dialogHost.ShowDialogAsync("AddTactics",null);
        }

        /// <summary>
        /// 弹出添加策略设置
        /// </summary>
        private void Add() 
        {
            _dialogHost.ShowDialogAsync("ModifyTactics",null);
        }

        /// <summary>
        /// 弹出删除提示框
        /// </summary>
        private void Del() 
        {
             _dialogHost.ShowDialogAsync("MsgView",null);
        }

        /// <summary>
        /// 加载策略设置信息
        /// </summary>
        private async void InitData()
        {
            await Task.Run(() =>
             {
                 App.Current.Dispatcher.BeginInvoke((Action)(() =>
                 {
                     //TacticsList.Add(new TacticsSettingsModel()
                     //{
                     //    SerialNo = 1,
                     //    Route ="一号线路",
                     //    RobotName = "Robot001",
                     //    Speed = "1m/s",
                     //    Interval ="0.1-3Km",
                     //    Model ="自动",
                     //    State ="巡检中",
                     //    EnableNow = "是"
                     //});
                     TacticsList = new ObservableCollection<TacticsSettingsModel>()
                     {
                        new TacticsSettingsModel()
                        {
                            SerialNo = 1,
                            Route ="一号线路",
                            RobotName = "Robot001",
                            Speed = "1m/s",
                            Interval ="0.1-3Km",
                            Model ="自动",
                            State ="巡检中",
                            EnableNow = "是"
                        },
                       new TacticsSettingsModel()
                        {
                            SerialNo = 2,
                            Route ="二号线路",
                            RobotName = "Robot002",
                            Speed = "1m/s",
                            Interval ="0.1-3Km",
                            Model ="自动",
                            State ="充电中",
                            EnableNow = "否"
                        },
                        new TacticsSettingsModel()
                        {
                            SerialNo = 3,
                            Route ="三号线路",
                            RobotName = "Robot003",
                            Speed = "1m/s",
                            Interval ="-",
                            Model ="手动",
                            State ="待命中",
                            EnableNow = "是"
                        },
                        new TacticsSettingsModel()
                        {
                            SerialNo = 4,
                            Route ="四号线路",
                            RobotName = "Robot004",
                            Speed = "1m/s",
                            Interval ="0.1-3Km",
                            Model ="自动",
                            State ="已关机",
                            EnableNow = "是"
                        },
                       new TacticsSettingsModel()
                        {
                            SerialNo = 5,
                            Route ="五号线路",
                            RobotName = "Robot005",
                            Speed = "1m/s",
                            Interval ="0.1-3Km",
                            Model ="自动",
                            State ="巡检中",
                            EnableNow = "是"
                        },
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
