using NFS.Model.Conveyor;
using NFS.Model.Home;
using NFS.Model.Line;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.ViewModels
{
   public class EnvironmentalAnalysisViewModel: BindableBase
    {
        public EnvironmentalAnalysisViewModel() 
        {
            InitData();
            InitAlarmRanking();

            #region 巡检线路、机器人下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            SimplifyRobot = new SimplifyRobotListModel();
            SimplifyRobotList = new ObservableCollection<SimplifyRobotListModel>();
            #endregion
        }

        #region 属性
        private ObservableCollection<EnvironmentalWarningModel> _environmentalWarningList;
        public ObservableCollection<EnvironmentalWarningModel> EnvironmentalWarningList
        {
            get { return _environmentalWarningList; }
            set 
            {
                _environmentalWarningList = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<AlarmRankingModel> _alarmRankingList;
        public ObservableCollection<AlarmRankingModel> AlarmRankingList
        {
            get { return _alarmRankingList; }
            set 
            {
                _alarmRankingList = value;
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
        #endregion

        /// <summary>
        /// 环境数据分析加载
        /// </summary>
        private async void InitData() 
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    EnvironmentalWarningList = new ObservableCollection<EnvironmentalWarningModel>()
                     {
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="温度",
                           AlarmValue="75mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="温度",
                           AlarmValue="90%"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="粉尘",
                           AlarmValue="90mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        },
                        new EnvironmentalWarningModel()
                        {
                          WarningTime="2021-08-17 15:30",
                          Location = "150m处",
                           AlertFactor="co",
                           AlarmValue="50mg/m³"
                        }
                     };
                }));
            });
        }

        /// <summary>
        /// 异常告警排行
        /// </summary>
        private async void InitAlarmRanking() 
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    AlarmRankingList = new ObservableCollection<AlarmRankingModel>()
                     {
                        new AlarmRankingModel()
                        {
                          Rank="1",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="2",
                          AlertFactor ="粉尘",
                          Location ="200m处",
                          AlarmsNumber =50
                        },
                        new AlarmRankingModel()
                        {
                          Rank="3",
                          AlertFactor ="噪声",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="4",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="5",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="6",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="7",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="8",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="9",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
                        },
                        new AlarmRankingModel()
                        {
                          Rank="10",
                          AlertFactor ="co",
                          Location ="200m处",
                          AlarmsNumber =75
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
