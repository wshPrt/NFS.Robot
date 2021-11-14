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
  public class ConveyorAnalysisViewModel: BindableBase
    {
        private readonly IDialogHostService _dialogHost;
        private readonly IRegionManager regiomManager;
        public  DelegateCommand maintainCommand { get; private set; } //打开托辊维护保养指令
        public DelegateCommand recommendCommand { get; private set; } //打开输送机检修建议指令
        public ConveyorAnalysisViewModel(IRegionManager regiomManager, IDialogHostService dialogHost) 
        {
            this.regiomManager = regiomManager;
            this._dialogHost = dialogHost;

            InitData();
            maintainCommand = new DelegateCommand(OpenMaintain);
            recommendCommand = new DelegateCommand(Recommend);

            #region 巡检线路下拉框
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            #endregion
        }

        #region 属性
        /// <summary>
        /// 历史警告List
        /// </summary>
        private ObservableCollection<HistoryAlertModel> _historyAlertList;
        public ObservableCollection<HistoryAlertModel> HistoryAlertList
        {
            get { return _historyAlertList; }
            set
            {
                _historyAlertList = value;
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
            set{ cmbSimplifyItem = value; }
        }
        #endregion

        private async void InitData()
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    HistoryAlertList = new ObservableCollection<HistoryAlertModel>()
                     {
                        new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="超温"
                        },
                         new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="异常"
                        },
                         new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="脱落"
                        },
                         new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="磨损"
                        },
                         new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="超温"
                        },
                         new HistoryAlertModel()
                        {
                            AlertTime="2021-08-17",
                            Location ="200米处",
                            AlertType="超温"
                        }
                        //,
                        // new HistoryAlertModel()
                        //{
                        //    AlertTime="2021-08-17",
                        //    Location ="200米处",
                        //    AlertType="超温"
                        //},
                        // new HistoryAlertModel()
                        //{
                        //    AlertTime="2021-08-17",
                        //    Location ="200米处",
                        //    AlertType="超温"
                        //},
                        // new HistoryAlertModel()
                        //{
                        //    AlertTime="2021-08-17",
                        //    Location ="200米处",
                        //    AlertType="超温"
                        //},
                        // new HistoryAlertModel()
                        //{
                        //    AlertTime="2021-08-17",
                        //    Location ="200米处",
                        //    AlertType="超温"
                        //},
                        // new HistoryAlertModel()
                        //{
                        //    AlertTime="2021-08-17",
                        //    Location ="200米处",
                        //    AlertType="超温"
                        //},
                     };
                }));
            });
        }
        private void OpenMaintain() 
        {
            _dialogHost.ShowDialogAsync("RollerMaintenance", null);
        }
        private void Recommend() 
        {
            _dialogHost.ShowDialogAsync("ConveyorOverhaul", null);
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
