using MaterialDesignThemes.Wpf;
using NFS.Commons.IniFiles;
using NFS.Commons.MD5Poxy;
using NFS.Model.LogIn;
using NFS.Robot.Interface;
using NFS.Robot.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NFS.Commons.IniFile.Configuration;
using static NFS.Model.LogIn.LoginModel;

namespace NFS.Robot.ViewModels
{
   public class LogInViewModel : BindableBase
    {
        public class LoginSentEvent : Prism.Events.PubSubEvent<bool> { }
        //IEventAggregator ea;
        //IContainerExtension _container;
        //IRegionManager _regionManager;
        //IRegion _region;
        //LogIn loginView;
        //MainWindow mainView;
        public LogInViewModel(IContainerExtension Container, IRegionManager regionManager, IEventAggregator eventAggregator) 
        {
            Title = "PHISHER";
            UserTitle = "智能巡检机器人管理系统";
            SnackbarMessage = new SnackbarMessageQueue();
            LoginInfo = new LoginModel();
            LoginList = new ObservableCollection<LoginModel>();
            CloseCommand = new DelegateCommand(CloseLogIn);
            LogInCommand = new DelegateCommand(SignIn);

            #region 接收登陆消息
            //ea = eventAggregator;
            //ea.GetEvent<LoginSentEvent>().Subscribe(MessageReceived);

            //_regionManager = regionManager;
            //_container = Container;
            //LoadDataCommand = new DelegateCommand(loadData);
            #endregion

        }

        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 登录标题
        /// </summary>
        private string userTitle;
        public string UserTitle
        {
            get { return userTitle; }
            set
            {
                userTitle = value;
                RaisePropertyChanged();
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        private bool toClose = false;
        /// <summary>
        /// 是否要关闭窗口
        /// </summary>
        public bool ToClose
        {
            get
            {
                return toClose;
            }
            set
            {
                if (toClose != value)
                {
                    toClose = value;
                    this.RaisePropertyChanged("ToClose");
                }
            }

        }

        /// <summary>
        /// 登陆指令
        /// </summary>
        public DelegateCommand LogInCommand { get; private set; }
        /// <summary>
        /// 关闭
        /// </summary>
        public DelegateCommand CloseCommand { get; private set;}
        /// <summary>
        /// 登陆加载
        /// </summary>
        public DelegateCommand LoadDataCommand { get; private set;}
        #endregion

        /// <summary>
        /// 账号信息
        /// </summary>
        private LoginModel _loginInfo;
        public LoginModel LoginInfo
        {
            get { return _loginInfo; }
            set 
            {
                _loginInfo = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 用户信息List
        /// </summary>
        private ObservableCollection<LoginModel> _loginList;
        public ObservableCollection<LoginModel> LoginList
        {
            get { return _loginList; }
            set 
            {
                _loginList = value;
                RaisePropertyChanged();
            }
        }

        private SnackbarMessageQueue snackbarMessageQueue;

        public event Action<IDialogResult> RequestClose;

        public SnackbarMessageQueue SnackbarMessage
        {
            get { return snackbarMessageQueue; }
            set 
            { 
                snackbarMessageQueue = value; 
                RaisePropertyChanged(); 
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        public void SignIn()
        {
            //LoginInfo.Account = "admin";
            //LoginInfo.Pwd = "123456";
            try
            {
                App.Current.Dispatcher.BeginInvoke((Action)(async () =>
                {
                    //App.Current.Dispatcher.Invoke(new Action(() =>
                    //{
                    if (string.IsNullOrWhiteSpace(LoginInfo.Account) || string.IsNullOrWhiteSpace(LoginInfo.Pwd))
                    {
                        LoginInfo.Warning = "请输入账号和密码!";
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(LoginInfo.Account) && !string.IsNullOrWhiteSpace(LoginInfo.Pwd))
                    {
                        SignIn objSignin = new SignIn();
                        var LoginTask = Task.Run(() => objSignin.AccountLogin(LoginInfo.Account, LoginInfo.Pwd));
                        #region 读取本地文件
                        //读取本地文件
                        //string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_CFG;
                        //var LoginTask = Task.Run(() =>
                        //{
                        //    if (File.Exists(cfgINI))
                        //    {
                        //        IniFile ini = new IniFile(cfgINI);
                        //        UserName = ini.IniReadValue("Login", "User");
                        //        PassWord = CEncoder.Decode(ini.IniReadValue("Login", "Password"));
                        //    }
                        //});
                        #endregion

                        var timeouttask = Task.Delay(3000);
                        var task = await Task.WhenAny(LoginTask, timeouttask);

                        if (task == timeouttask)
                        {
                            LoginInfo.Warning = "系统连接超时,请联系管理员!";
                        }
                        else
                        {
                            var data = LoginTask.Result;
                           // SaveLoginInfo();
                            var userList = data;
                            var success = data.msg.ToString();
                            if (success != null && success== "success")
                            {
                                LoginInfo.Account = "";
                                LoginInfo.Pwd = "";
                                LoginInfo.MonitorCode = "";
                                ToClose = true;
                                return;
                            }
                            else
                            {
                                LoginInfo.Warning = "账号或密码错误!";
                            }
                        }
                    }
                    else
                    {
                        LoginInfo.Warning = "密码或账号不能空！";
                        return;
                    }
                    //}));
                }));
            }
            catch (Exception ex)
            {
                LoginInfo.Warning = ex.ToString();
            }

        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        private void SaveLoginInfo()
        {
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + SerivceFiguration.INI_CFG;
            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("Login", "User", LoginInfo.Account);
            ini.IniWriteValue("Login", "Password", CEncoder.Encode(LoginInfo.Pwd));
            ini.IniWriteValue("Login", "SaveInfo", "Y");
        }
        /// <summary>
        /// 关闭登陆
        /// </summary>
        private void CloseLogIn() 
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 登陆加载
        /// </summary>
        //private void loadData() 
        //{
        //    //loginView = _container.Register<LogIn>();
        //    //_region.Add(LogInViewModel);
        //}
        //private void MessageReceived(bool loginState)
        //{
        //    if (loginState)
        //    {
        //        _region.Deactivate(loginView);

        //        mainView = _container.Resolve<MainWindow>();

        //        _region.Add(mainView);
               
        //    }
        //}

        //public bool CanCloseDialog()
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnDialogClosed()
        //{
            
        //}

        //public void OnDialogOpened(IDialogParameters parameters)
        //{
            
        //}
    }
}
