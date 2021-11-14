using LiveCharts;
using LiveCharts.Helpers;
using NFS.Commons.ScoketClient;
using NFS.Model.Line;
using NFS.Model.Robot;
using NFS.Robot.Interface;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

namespace NFS.Robot.ViewModels
{
    /// <summary>
    /// 噪声强度VM
    /// </summary>
    public class NoiseAnalysisViewModel:BindableBase
    {
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2") + " ";
                }
            }
            return returnStr;
        }
        public static TcpSocketClient _tcp;
        private NoisyCollection<short> pcmList = new NoisyCollection<short>();
        public ChartValues<short> AppleDataSeries { get; set; }

        public NoisyCollection<short> PCMList
        {
            get { return pcmList; }
            set { pcmList = value;RaisePropertyChanged("PCMList"); }
        }
        public  NoiseAnalysisViewModel()
        {
            SimplifyLine = new SimplifyLineListModel();
            SimplifyLineList = new ObservableCollection<SimplifyLineListModel>();
            InitLineList();
            SimplifyRobot = new SimplifyRobotListModel();
            SimplifyRobotList = new ObservableCollection<SimplifyRobotListModel>();
            AppleDataSeries = new ChartValues<short>();
            //开启Scoket
            Task.Run(() =>
            {
                _tcp = new TcpSocketClient();
                Data obj = new Data();
                //_tcp._Receipt += obj._tcp_Receipt;

                _tcp.OnReceiveBuffer += (buffer) =>
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        AppleDataSeries.Add((short)new Random().Next(1, 99));
                    });
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        //Console.WriteLine(ByteToHexStr(buffer));
                        for (int i = 0; i < buffer.Length; i = i + 2)
                        {
                            byte[] temp = new byte[2];
                            temp[0] = buffer[i];
                            temp[1] = buffer[i + 1];
                            short number = BitConverter.ToInt16(temp, 0);
                          //  AppleDataSeries.Add(number);
                           // Console.Write(number);
                        }
                    });
                };
            });
        }

        private void _tcp__Receipt(object sender, TcpSocketClient.CmdDataPacket e)
        {
            throw new NotImplementedException();
        }

        #region 属性、字段
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
