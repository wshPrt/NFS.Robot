using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.Resource.Dialog
{
    public class DialogHostService : DialogService, IDialogHostService
    {
        private readonly IContainerExtension containerExtension;
        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this.containerExtension = containerExtension;
        }

        //public async Task<IDialogResult> ShowDialogAsync(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        //{
        //    if (parameters == null)
        //        parameters = new DialogParameters();
        //    //容器当中取出实例
        //    var content = containerExtension.Resolve<object>(name);
        //    if (!(content is FrameworkElement dialogContent))
        //        throw new NullReferenceException("A dialog's content must be a FrameworkElement");
        //    //绑定上下文
        //    if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
        //        ViewModelLocator.SetAutoWireViewModel(view, true);
        //    if (!(dialogContent.DataContext is IDialogAware viewModel))
        //        throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");
        //    if (viewModel != null) viewModel.OnDialogOpened(parameters);
        //    //往DialogHost 名为Rootde 的节点当中设置内容,Content
        //    return (IDialogResult)DialogHost.Show(content, "Root");
        //}

        public async Task<IDialogResult> ShowDialogAsync(string name, IDialogParameters parameters, string dialogHostName = "Root")
        {
            if (parameters == null)
                parameters = new DialogParameters();
            //容器当中取出实例
            var content = containerExtension.Resolve<object>(name);
            if (!(content is FrameworkElement dialogContent))
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");
            //绑定上下文
            if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
                ViewModelLocator.SetAutoWireViewModel(view, true);
            if (!(dialogContent.DataContext is IDialogAware viewModel))
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");
            if (viewModel != null) viewModel.OnDialogOpened(parameters);
            //往DialogHost 名为Rootde 的节点当中设置内容,Content
            return (IDialogResult)DialogHost.Show(content, "Root");
        }


        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "Root")
        {
            if (parameters == null)
                parameters = new DialogParameters();

            //从容器当中去除弹出窗口的实例
            var content = containerExtension.Resolve<object>(name);

            //验证实例的有效性 
            if (!(content is FrameworkElement dialogContent))
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");

            if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
                ViewModelLocator.SetAutoWireViewModel(view, true);

            if (!(dialogContent.DataContext is IDialogHostAware viewModel))
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");

            viewModel.DialogHostName = dialogHostName;

            DialogOpenedEventHandler eventHandler = (sender, eventArgs) =>
            {
                if (viewModel is IDialogHostAware aware)
                {
                    aware.OnDialogOpend(parameters);
                }
                eventArgs.Session.UpdateContent(content);
            };

            return (IDialogResult)await DialogHost.Show(dialogContent, viewModel.DialogHostName, eventHandler);
        }
    }
}
