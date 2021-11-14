using NFS.Model.DataCenter;
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

namespace NFS.Robot.ViewModels
{
   public class UserManageViewModel: BindableBase
    {
        private readonly IDialogHostService _dialogHost;
        private readonly IRegionManager regiomManager;
        public DelegateCommand ModifyPasswordCommand { get; private set; }
        public UserManageViewModel(IRegionManager regiomManager, IDialogHostService dialogHost)
        {
            this.regiomManager = regiomManager;
            this._dialogHost = dialogHost;
            ModifyPasswordCommand = new DelegateCommand(ModifyPwd);
            InitUser();
        }

        /// <summary>
        /// 用户管理List
        /// </summary>
        private ObservableCollection<UserManage> _userManageList;
        public ObservableCollection<UserManage> UserManageList
        {
            get { return _userManageList; }
            set 
            {
                _userManageList = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 打开修改登录密码
        /// </summary>
        private void ModifyPwd()
        {
            _dialogHost.ShowDialogAsync("ModifyPassword", null);
        }


        /// <summary>
        /// 加载用户管理
        /// </summary>
        private async void InitUser() 
        {
           await Task.Run(() =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    UserManageList = new ObservableCollection<UserManage>()
                    {
                        new UserManage()
                        {
                              SerialNumber =1,
                               UserName="admin",
                               UserPower="系统管理员",
                               PassWord="123456"
                        },
                        new UserManage()
                        {
                              SerialNumber =2,
                               UserName="sa",
                               UserPower="系统管理员",
                               PassWord="123456"
                        },
                        new UserManage()
                        {
                              SerialNumber =3,
                               UserName="root",
                               UserPower="系统管理员",
                               PassWord="123456"
                        },
                        new UserManage()
                        {
                              SerialNumber =4,
                               UserName="Administrator",
                               UserPower="系统管理员",
                               PassWord="123456"
                        }
                    };
                }));
            });
        }
    }
}
