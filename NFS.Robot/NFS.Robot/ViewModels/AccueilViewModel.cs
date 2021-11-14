using NFS.Model.Home;
using NFS.Robot.Interface;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.ViewModels
{
   public  class AccueilViewModel: BindableBase
    {
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }
        public AccueilViewModel() 
        {
            Content = "PHISHER";

            #region 下拉框
            RouteFormList = new ObservableCollection<RouteFormModel>();
           // InitRouteForm();
            #endregion

            #region 获取机器人列表
            GetRobot = new GetRobotListModel();
            GetRobotList = new ObservableCollection<GetRobotListModel>();
            #endregion
        }

        #region 路线(下拉框)
        private ObservableCollection<RouteFormModel> _routeFormList;
        public ObservableCollection<RouteFormModel> RouteFormList
        {
            get { return _routeFormList; }
            set { _routeFormList = value; }
        }

        private RouteFormModel cmbRouteItem;
        public RouteFormModel CmbRouteItem
        {
            get { return cmbRouteItem; }
            set
            {
                cmbRouteItem = value;

                if (value != null && value.Id > 0)
                {
                    InitGetRobotList();
                }
            }
        }

        #region 获取机器人列表
        private GetRobotListModel getRobot;
        public GetRobotListModel GetRobot
        {
            get { return getRobot; }
            set { getRobot = value; }
        }

        private ObservableCollection<GetRobotListModel> _getRobotList;
        public ObservableCollection<GetRobotListModel> GetRobotList
        {
            get { return _getRobotList; }
            set { _getRobotList = value; }
        }

        private ObservableCollection<GetRobotListModel> _Obs_GetRobotListModel;
        public ObservableCollection<GetRobotListModel> Obs_GetRobotListModel
        {
            get { return _Obs_GetRobotListModel; }
            set { _Obs_GetRobotListModel = value; }
        }

        private GetRobotListModel cmbRobotItem;
        public GetRobotListModel CmbRobotItem
        {
            get { return cmbRobotItem; }
            set
            {
                cmbRobotItem = value;
            }
        }

        #endregion

        /// <summary>
        /// 根据路线ID获取机器人列表
        /// </summary>
        private async void InitGetRobotList()
        {
            await Task.Run(() =>
            {
                int lineId = CmbRouteItem.Id;
                IGetListRobots getRobots = new IGetListRobots();
                var result = getRobots.QueryRoutes(lineId).Result;
                string success = result.msg;
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (success == "success")
                    {
                        for (int i = 0; i < result.list.Count; i++)
                        {
                            GetRobotListModel robotList = new GetRobotListModel()
                            {
                                Id = result.list[i].id,
                                RobotNumber = result.list[i].robot_code,
                                RobotName = result.list[i].robot_name
                            };

                            var obj = GetRobotList.ToList().Find(target => target.Id.Equals(result.list[i].id));
                            if (obj != null)
                            {
                                obj = robotList;
                            }
                            else
                                GetRobotList.Add(robotList);
                        }

                        Obs_GetRobotListModel = new ObservableCollection<GetRobotListModel>(GetRobotList);
                    }
                    else
                    {
                        MessageBox.Show(success);
                    }
                }));
            });
        }

        /// <summary>
        /// 路线列表
        /// </summary>
        private async void InitRouteForm()
        {
            await Task.Run(() =>
            {
                IRouteListForm form = new IRouteListForm();
                var result = form.RouteListForm().Result;
                string success = result.msg;
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (success == "success")
                    {
                        for (int i = 0; i < result.list.Count; i++)
                        {
                            RouteFormList.Add(new RouteFormModel()
                            {
                                Id = result.list[i].id,
                                LineName = result.list[i].line_name
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
        #endregion

     
    }
}
