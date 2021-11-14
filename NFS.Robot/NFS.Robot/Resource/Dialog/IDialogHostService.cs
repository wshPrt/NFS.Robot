using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.Resource.Dialog
{
    public interface IDialogHostService : IDialogService
    {
        //Task<IDialogResult> ShowDialogAsync(string name, IDialogParameters parameters, Action<IDialogResult> callback);
        //new void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback);

        Task<IDialogResult> ShowDialogAsync(string name, IDialogParameters parameters, string dialogHostName = "Root");
    }
}
