using NFS.Model.Robot;
using NFS.Robot.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
  public class RightHomeViewModel:BindableBase
    {
        public RightHomeViewModel()
        {
            RefreshCommamd = new DelegateCommand(InitRefresh);
            SelectionChangedCommamd = new DelegateCommand(InitSelectionChanged);
            RobotOnline = new RobotOnlineListModel();
            RobotOnlineList = new ObservableCollection<RobotOnlineListModel>();
            InitRobotOnlineList();
        }
        #region 获取机器人在线列表
        private RobotOnlineListModel _robotOnline;
        public RobotOnlineListModel RobotOnline
        {
            get { return _robotOnline; }
            set
            {
                _robotOnline = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<RobotOnlineListModel> _robotOnlineList;
        public ObservableCollection<RobotOnlineListModel> RobotOnlineList
        {
            get { return _robotOnlineList; }
            set { _robotOnlineList = value; }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        private int _onlineState = 2;
        public int OnlineState
        {
            get { return _onlineState; }
            set { _onlineState = value; }
        }

        /// <summary>
        /// 刷新机器人列表指令
        /// </summary>
        public DelegateCommand RefreshCommamd { get; private set; }
        /// <summary>
        /// Tab切换指令
        /// </summary>
        public DelegateCommand SelectionChangedCommamd { get; private set; }
        #endregion

        /// <summary>
        /// 获取机器人在线列表
        /// </summary>
        private async void InitRobotOnlineList() 
        {
           await Task.Run(() => 
            {
                int is_online = OnlineState;
                RobotOnlineList robotOnline = new RobotOnlineList();
                var reuslt = robotOnline.GetRobotOnlineList(is_online).Result;
                string success = reuslt.msg;
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    if (success == "读取成功")
                    {
                        for (int i = 0; i < reuslt.data.Count; i++)
                        {
                            RobotOnlineList.Add(new RobotOnlineListModel()
                            {
                                LineId = reuslt.data[i].lineId,
                                RobotCode = reuslt.data[i].robotCode,
                                RobotName = reuslt.data[i].robotName,
                                RobotState = reuslt.data[i].robotState,
                                WorkState = reuslt.data[i].workState,
                                IsOnline = reuslt.data[i].isOnline,
                                Speed = Convert.ToDecimal(reuslt.data[i].speed),
                                Battery = reuslt.data[i].battery + "%",
                                LineName= reuslt.data[i].lineName
                            });
                        }
                    }
                }));
            });
        }

        /// <summary>
        /// 刷新机器人列表
        /// </summary>
        private async void InitRefresh() 
        {
            await Task.Run(() =>
             {
                 App.Current.Dispatcher.Invoke((Action)(() =>
                 {
                     RobotOnlineList.Clear();
                     InitRobotOnlineList();
                 }));
             });
        }
        /// <summary>
        /// Tab切换机器在线或离线
        /// </summary>
        private void InitSelectionChanged() 
        {
            OnlineState = 1;
            InitRobotOnlineList();
        }
    }
}
