using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
    public class MsgViewModel : BindableBase,IDialogAware
    {
        public MsgViewModel() 
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }


        private string title;
        public string Title
        {
            get { return title; }
            set { title = value;  RaisePropertyChanged();}
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel() 
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
            }
        }
        /// <summary>
        /// 保存      
        /// </summary>
        private void Save() 
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title)) return;

            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters param = new DialogParameters();
                param.Add("Value", title);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
        }

        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            DialogParameters param = new DialogParameters();
            param.Add("Value", "123");
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Value");
        }
    }
}
