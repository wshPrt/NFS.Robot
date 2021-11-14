using NFS.Commons.Base;
using NFS.Model.Home;
using NFS.Robot.Interface;
using NFS.Robot.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region 属性
        private string _title = "PHISHER";
        public string Title
        {
            get { return _title; }
        }

        private string _titleVertical = " ";
        public string TitleVertical
        {
            get { return _titleVertical; }
        }

        private string _titleName;
        public string TitleName
        {
            get { return _titleName; }
            set { _titleName = value; RaisePropertyChanged();}
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        private Visibility _leftVisibility = Visibility.Visible;
        public Visibility LeftVisibility
        {
            get { return _leftVisibility; }
            set { _leftVisibility = value; RaisePropertyChanged();}
        }
        private Visibility _rightVisibility = Visibility.Visible;
        public Visibility RightVisibility
        {
            get { return _rightVisibility; }
            set { _rightVisibility = value; RaisePropertyChanged();}
        }
        #endregion

        #region Command指令
        public DelegateCommand<string> HomeCommand { get; private set; }
        public DelegateCommand<object> RobotCommand { get; private set; }
        public DelegateCommand<string> ConveyorCommand { get; private set; }
        public DelegateCommand<string> DataCenterCommand { get; private set; }
        public DelegateCommand<string> AnalysisCommand { get; private set; }
        public DelegateCommand<string> LocationCommand { get; private set;}
        public DelegateCommand<string> PolicyCommand { get; private set;}
        public DelegateCommand<string> RollerCommand { get; private set;}
        public DelegateCommand MouseOverCommand { get; private set;}
        public DelegateCommand MouseLeaveCommand { get; private set; }
        public DelegateCommand<string> NoiseAnalysisCommand { get; private set; }
        public DelegateCommand<string> RobotVibrationCommand { get; private set;}
        public DelegateCommand<string> PolicySettingCommand { get; private set;}
        public DelegateCommand<string> RollerAnalysisCommand { get; private set; }
        public DelegateCommand<string> MaintainRecordCommand { get; private set; }
        public CommandBase TabChangedCommand { get; set; }
        public DelegateCommand<string> EnvironmentDataCommand { get; private set; }
        public DelegateCommand<string> FullScreenVideoCommand { get; private set; }
        public DelegateCommand<string> UserCenterCommand{ get; private set; }
        private readonly IRegionManager regionManager;
        #endregion

        //private System.Windows.Forms.Timer timerGetTime;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            Content = "PHISHER";
            TitleName = "智能巡检机器人管理系统";

            #region 导航栏
            this.regionManager = regionManager;
            HomeCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("Accueil");
                LeftVisibility = Visibility.Visible;
            });
            RobotCommand = new DelegateCommand<object>(arg =>
            {
                if (arg == null) return;
                regionManager.Regions["RegionContent"].RequestNavigate("Robots");
                LeftVisibility = Visibility.Hidden;
            });
            ConveyorCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("ConveyorAnalysis");
                LeftVisibility = Visibility.Hidden;
            });
            DataCenterCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("DataCenter");
                LeftVisibility = Visibility.Hidden;
            });
            #endregion

            #region 机器人下拉
            //托辊测温
            RollerCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("RollerTemperature");
                LeftVisibility = Visibility.Hidden;
            });
            //环境数据
            EnvironmentDataCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("EnvironmentData");
                LeftVisibility = Visibility.Hidden;
            });
            #endregion

            #region 输送机下拉
            AnalysisCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("EnvironmentalAnalysis");
                LeftVisibility = Visibility.Hidden;
            });
            RollerAnalysisCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("RollerAnalysis");
                LeftVisibility = Visibility.Hidden;
            });
            LocationCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("Location");
                LeftVisibility = Visibility.Hidden;
            });
            MaintainRecordCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("MaintainRecord");
                LeftVisibility = Visibility.Hidden;
            });
            NoiseAnalysisCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("NoiseAnalysis");
                LeftVisibility = Visibility.Hidden;
            });
            RobotVibrationCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("RobotVibration");
                LeftVisibility = Visibility.Hidden;
            });
            #endregion

            PolicyCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("UserControl1");
            });
            PolicySettingCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("PolicySetting");
                LeftVisibility = Visibility.Hidden;
            });
            MouseOverCommand = new DelegateCommand(()=>
            {
                if (!StrIsOpen)
                {
                    StrIsOpen = true;
                }
               
            });
            MouseLeaveCommand = new DelegateCommand(() =>
            {
                if (StrIsOpen)
                {
                    StrIsOpen = false;
                }
               
            });

            //视频全屏
            FullScreenVideoCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("FullScreenVideo");
                RightVisibility = Visibility.Hidden;
                LeftVisibility = Visibility.Hidden;
            });
            #region 数据中心下拉
            //用户管理
            UserCenterCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("UserManage");
                LeftVisibility = Visibility.Hidden;
            });
            #endregion
        }

        private bool _strIsOpen;
        public bool StrIsOpen
        {
            get { return _strIsOpen; }
            set 
            {
                _strIsOpen = value;
                RaisePropertyChanged();
            }
        }

    }
}
