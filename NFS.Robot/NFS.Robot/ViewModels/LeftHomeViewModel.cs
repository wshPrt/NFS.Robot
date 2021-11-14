using NFS.Commons.Base;
using NFS.Model;
using NFS.Model.Home;
using NFS.Model.Line;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WebSocketSharp;

namespace NFS.Robot.ViewModels
{
   public class LeftHomeViewModel: BindableBase
    {
        /// <summary>
        /// 巡检Value
        /// </summary>
        private string _cruiseValue ="手动巡检";
        public string CruiseValue
        {
            get { return _cruiseValue; }
            set 
            {
                _cruiseValue = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 巡检状态
        /// </summary>
        /// False表示手动、True表示自动
        private bool _cruiseStatus=false;
        public bool CruiseStatus
        {
            get { return _cruiseStatus; }
            set 
            {
                _cruiseStatus = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 发送内容
        /// </summary>
        public string SendContent { get; set; }

        public DelegateCommand<string> OpenPTZCommand { get; private set; }//打开云台指令
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        private Visibility _leftVisibility = Visibility.Visible;
        public Visibility LeftVisibility
        {
            get { return _leftVisibility; }
            set { _leftVisibility = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<string> ReturnHomeCommand { get; private set; }//返回主页
        public DelegateCommand StopCommand { get; private set; }//停止指令
        public DelegateCommand BackCommand { get; private set;}//快退
        public DelegateCommand AdvanceCommand { get; private set; }//前进
        public DelegateCommand SportsCommand { get; private set;}//运动模式
        public DelegateCommand CruiseCommand { get; private set; }//自动、手动巡检
        public DelegateCommand<object> LoadedCommand { get; private set; }//加载
        #region WebSocket
        private WebSocket websocket = new WebSocket("ws://121.196.123.245:6050");
        Queue<action> actions = new Queue<action>();//命令队列
        action currentAction = null;//记录当前指令
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="title">指令</param>
        /// <param name="callBack">指令的会回调</param>
        private void sendAction(string title, Action<string, string> callBack)
        {
            this.actions.Enqueue(new LeftHomeViewModel.action()
            {
                title = title,
                callBack = callBack
            });
        }
        /// <summary>
        /// 发送心跳
        /// </summary>
        /// <param name="title">指令</param>
        /// <param name="callBack">指令的会回调</param>
        private void sendAction(Action<string, string> callBack)
        {
            this.actions.Enqueue(new LeftHomeViewModel.action()
            {
                isPing = true,
                callBack = callBack
            });
        }
        #endregion

        public LeftHomeViewModel(IRegionManager regionManager,IEventAggregator eventAggregator) 
        {
            this.regionManager = regionManager;
            OpenPTZCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("PTZVideo");
                LeftVisibility = Visibility.Hidden;
            });
            ReturnHomeCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("Accueil");
                LeftVisibility = Visibility.Visible;
            });

            #region 线路下拉框
            OrdinaryLine = new OrdinaryLineListModel();
            OrdinaryLineList = new ObservableCollection<OrdinaryLineListModel>();
            InitOrdinaryLine();
            //SimplifyLine = new SimplifyLineListModel();
            //SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            //InitLineList();
            SimplifyRobot = new SimplifyRobotListModel();
            SimplifyRobotList = new ObservableCollection<SimplifyRobotListModel>();
            RobotInfo = new RobotInfoModel();
            RobotInfoList = new ObservableCollection<RobotInfoModel>();
            #endregion

            #region websocket 接收消息
            //websocket.OnMessage += Websocket_OnMessage;
            //websocket.OnOpen += Websocket_OnOpen;
            //websocket.ConnectAsync();
            //Task.Run(() =>
            //{
            //    //开一个单独的线程进行指令的发送
            //    while (true)
            //    {
            //        if (this.currentAction != null)
            //        {
            //            //指令还未回调完成
            //            Thread.Sleep(100);
            //            continue;
            //        }
            //        if (this.websocket.ReadyState == WebSocketState.Open && this.actions.Count > 0)
            //        {
            //            this.currentAction = this.actions.Dequeue();
            //            if (this.currentAction.isPing == true)
            //            {
            //                this.websocket.Ping();
            //            }
            //            else
            //            {
            //                this.websocket.Send(this.currentAction.title);//发送指令
            //            }
            //        }
            //        else
            //        {
            //            //未有指令或者websocket未准备好
            //            Thread.Sleep(100);
            //            continue;
            //        }

            //    }
            //});

            StopCommand = new DelegateCommand(Stop);
            BackCommand = new DelegateCommand(Back);
            AdvanceCommand = new DelegateCommand(Advance);
            SportsCommand = new DelegateCommand(Sports);
            CruiseCommand = new DelegateCommand(Cruise);
            #endregion
            this.eventAggregator = eventAggregator;
        }

        //private void OnMessageReceived(MessageModel obj)
        //{
        //    SendContent += obj + "\r\n";
        //}
        public void OnMessageReceived(string message)
        {
            SendContent += message + "\r\n";
        }

        #region WebSocket
        private void Websocket_OnMessage(object sender, MessageEventArgs e)
        {
            //自动接收推送的数据
            if (e.IsBinary)
            {
                Console.WriteLine("二进制数据" + Convert.ToBase64String(e.RawData));
            }
            else if (e.IsText)
            {
                Console.WriteLine("文本数据：" + e.Data);
                if (this.currentAction != null)
                {
                    Task.Factory.StartNew((o) =>
                    {
                        actionCallBack obj = (actionCallBack)o;
                        obj.callBack(obj.title, obj.callBackData);//回调，执行指令，返回的值
                    }, new actionCallBack { title = this.currentAction.title, callBack = this.currentAction.callBack, callBackData = e.Data });
                    this.currentAction = null;//清空当前指令，进行下个指令   
                }
            }
            else if (e.IsPing)
            {
                Console.WriteLine("心跳数据");
            }
        }
        private void Websocket_OnOpen(object sender, EventArgs e)
        {
            // websocket.Send("login,client001,web");//先需要登录,第二个参数应该是对应的设备
            websocket.Send("login,fs-robot-1,web");//先需要登录,第二个参数应该是对应的设备
            Task.Run(() =>
            {
                while (true)
                {
                    this.sendAction((title, callBack) =>
                    {
                         try
                            {
                                //this.CurrentRoller.Text = "robot00" + callBack.Split(',')[1];
                                //this.LeftTemp.Text = "左" + (float.Parse(callBack.Split(',')[2]) / 10).ToString("0.0") + "℃";
                                //this.MiddleTemp.Text = "中" + (float.Parse(callBack.Split(',')[3]) / 10).ToString("0.0") + "℃";
                                //this.RightTemp.Text = "右" + (float.Parse(callBack.Split(',')[4]) / 10).ToString("0.0") + "℃";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        });
                    //定时，后继续发送心跳
                    Thread.Sleep(1000);//
                }
            });
        }
        class action
        {
            public bool isPing { get; set; }
            public string title { get; set; }//指令
            public Action<string, string> callBack { get; set; }//回调
        }
        class actionCallBack
        {
            public string title { get; set; }//指令
            public Action<string, string> callBack { get; set; }//回调
            public string callBackData { get; set; }
        }
        #endregion

        /// <summary>
        /// 自动、手动巡检
        /// </summary>
        private void Cruise() 
        {
            websocket.Connect();
            if (CruiseStatus != false)
            {
                websocket.Send("auto，1");//退出自动状态
                websocket.Send("man，0, 0"); //进入收到状态
                CruiseStatus = false;
                CruiseValue = "手动巡检";
            }
            else 
            {
                websocket.Send("man，1, 0");//退出手动状态
                websocket.Send("auto，0");//进入自动状态
                CruiseStatus = true;
                CruiseValue = "自动巡检";
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        private void Stop() 
        {
            websocket.Connect();
            websocket.Send("man,2,0");//暂停
        }

        /// <summary>
        /// 后退
        /// </summary>
        private void Back() 
        {
            websocket.Connect();
            websocket.Send("speed,4,100");//后退
        }

        /// <summary>
        /// 前进
        /// </summary>
        private void Advance() 
        {
            websocket.Connect();
            websocket.Send("man,3,0");
        }

        /// <summary>
        /// 运动模式
        /// </summary>
        private void Sports() 
        {
            websocket.Connect();
            websocket.Send("man,6,12000");
            websocket.Send("motor,20,robot001");
        }

        #region 属性
        /// <summary>
        ///  获取线路列表—普通
        /// </summary>
        private OrdinaryLineListModel _ordinaryLine;
        public OrdinaryLineListModel OrdinaryLine
        {
            get { return _ordinaryLine; }
            set { _ordinaryLine = value; RaisePropertyChanged(); }
        }
        private OrdinaryLineListModel cmbOrdinaryLineItem;
        public OrdinaryLineListModel CmbOrdinaryLineItem
        {
            get { return cmbOrdinaryLineItem; }
            set
            {
                cmbOrdinaryLineItem = value;
                if (value != null && value.LineId > 0)
                {
                    InitSimplifyRobotList();
                }
            }
        }
        private ObservableCollection<OrdinaryLineListModel> _ordinaryLineList;
        public ObservableCollection<OrdinaryLineListModel> OrdinaryLineList
        {
            get { return _ordinaryLineList; }
            set { _ordinaryLineList = value; RaisePropertyChanged(); }
        }
        #region 获取线路列表—精简
        //private SimplifyLineListModel cmbSimplifyItem;
        //public SimplifyLineListModel CmbSimplifyItem
        //{
        //    get { return cmbSimplifyItem; }
        //    set
        //    {
        //        cmbSimplifyItem = value;
        //        if (value != null && value.LineId > 0)
        //        {
        //            InitSimplifyRobotList();
        //        }
        //    }
        //}
        //private SimplifyLineListModel _simplifyLine;
        //public SimplifyLineListModel SimplifyLine
        //{
        //    get { return _simplifyLine; }
        //    set { _simplifyLine = value; }
        //}
        //private ObservableCollection<SimplifyLineListModel> _simplifyLineList;
        //public ObservableCollection<SimplifyLineListModel> SimplifyLineList
        //{
        //    get { return _simplifyLineList; }
        //    set { _simplifyLineList = value; RaisePropertyChanged(); }
        //}
        #endregion

        /// <summary>
        /// 获取机器人列表—精简
        /// </summary>
        private SimplifyRobotListModel _simplifyRobot;
        public SimplifyRobotListModel SimplifyRobot
        {
            get { return _simplifyRobot; }
            set { _simplifyRobot = value; }
        }
        private ObservableCollection<SimplifyRobotListModel> _simplifyRobotList;
        public ObservableCollection<SimplifyRobotListModel> SimplifyRobotList
        {
            get { return _simplifyRobotList; }
            set { _simplifyRobotList = value; }
        }
        /// <summary>
        /// 获取机器人信息
        /// </summary>
        private RobotInfoModel _robotInfo;
        public RobotInfoModel RobotInfo
        {
            get { return _robotInfo; }
            set { _robotInfo = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<RobotInfoModel> _RobotInfoList;
        public ObservableCollection<RobotInfoModel> RobotInfoList
        {
            get { return _RobotInfoList; }
            set { _RobotInfoList = value; RaisePropertyChanged(); }
        }
        #endregion

        /// <summary>
        /// 获取线路列表—普通
        /// </summary>
        private async void InitOrdinaryLine()
        {
            await Task.Run(() =>
             {
                 OrdinaryLineList ordinaryLine = new OrdinaryLineList();
                 var result = ordinaryLine.GetLineList().Result;
                 string success = result.msg;
                 App.Current.Dispatcher.BeginInvoke((Action)(() =>
                 {
                     if (success == "读取成功")
                     {
                         for (int i = 0; i < result.data.Count; i++)
                         {
                             OrdinaryLineList.Add(new OrdinaryLineListModel()
                             {
                                 LineId = result.data[i].id,
                                 LineName = result.data[i].lineName,
                                 AlarmState = result.data[i].lineAlarmState,
                                 AlarmContent = result.data[i].lineAlarmName,
                                 Coordinates = result.data[i].linePointer
                             });
                         }
                         //OrdinaryLineList[0].Coordinates.Split(',')[0].Split('[')

                     }
                 }));
             });
        }
        /// <summary>
        /// 获取线路列表(精简)
        /// </summary>
        //private async void InitLineList()
        //{
        //    await Task.Run(() =>
        //    {
        //        SimplifyLineList simplify = new SimplifyLineList();
        //        var result = simplify.GetLineList().Result;
        //        string success = result.msg;
        //        App.Current.Dispatcher.BeginInvoke((Action)(() =>
        //        {
        //            if (success=="读取成功")
        //            {
        //                for (int i = 0; i < result.data.Count; i++)
        //                {
        //                    SimplifyLineList.Add(new SimplifyLineListModel()
        //                    {
        //                        LineId = result.data[i].id,
        //                        LineName =result.data[i].lineName
        //                    });
        //                }
        //            }
        //            else 
        //            {
        //                MessageBox.Show(success);
        //            }
        //        }));
        //    });
        //}
        /// <summary>
        /// 获取机器人列表(精简)
        /// </summary>
        private async void InitSimplifyRobotList()
        {
           await Task.Run(() =>
            {
                SimplifyRobotList simplifyRobot = new SimplifyRobotList();
                var result = simplifyRobot.GetSimplifyRobotList(CmbOrdinaryLineItem.LineId).Result;
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
            //刷选第0条数据机器人ID
            SimplifyRobot.RobotId = SimplifyRobotList.OrderBy(x => x.RobotId).ToList()[0].RobotId;
            InitRobotInfo();
        }
        /// <summary>
        /// 获取机器人信息
        /// </summary>
        private async void InitRobotInfo()
        {
            await Task.Run(() =>
            {
                int robotId = SimplifyRobot.RobotId;//机器人ID
                GetRobotInfo getRobotInfo = new GetRobotInfo();
                var result = getRobotInfo.GetLineList(robotId).Result;
                string success = result.msg;
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    if (success == "读取成功")
                    {
                        RobotInfoList.Add(new RobotInfoModel()
                        {
                            RobotId = result.data.id,
                            RobotMacAddress = result.data.robotMac,
                            RobotNumber = result.data.robotCode,
                            RobotState = result.data.robotState,
                            IsOnLine = result.data.isOnline,
                            Speed = Convert.ToDecimal(result.data.speed),
                            Battery = result.data.battery,
                            RechargeMileage = result.data.endurance
                        });
                    }
                }));
            });
            UserToken.electricity = RobotInfoList.OrderBy(x => x.Battery).ToList()[0].Battery;
            UserToken.mileage = Convert.ToInt32(RobotInfoList.OrderBy(x => x.RechargeMileage).ToList()[0].RechargeMileage);
            UserToken.speed = RobotInfoList.OrderBy(x => x.Speed).ToList()[0].Speed;
            
            SendMessage(UserToken.mileage.ToString());
            SendMessage(UserToken.electricity.ToString());
            //SendMessage(UserToken.speed.ToString());
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="Meesage"></param>
        public static void SendMessage(string Meesage) 
        {
            EventAggregatorRepository
                .GetInstance()
                .eventAggregator
                .GetEvent<GetInputMessages>()
                .Publish(Meesage);
        }
    }
}
