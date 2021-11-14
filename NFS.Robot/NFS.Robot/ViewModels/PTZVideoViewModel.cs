using NFS.Robot.Resource.TimeLine;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
   public class PTZVideoViewModel: BindableBase
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> MainCommand { get; private set; }
        public PTZVideoViewModel(IRegionManager regionManager) 
        {
            this.regionManager = regionManager;
            MainCommand = new DelegateCommand<string>(arg =>
            {
                regionManager.Regions["RegionContent"].RequestNavigate("Accueil");
            });
        }
    }
}
