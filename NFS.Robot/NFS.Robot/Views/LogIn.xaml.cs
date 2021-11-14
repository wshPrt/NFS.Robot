using NFS.Robot.ViewModels;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NFS.Robot.Views
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class LogIn : Window
    {
        private readonly IContainerExtension _container;
        private readonly IRegionManager _regionManager;
        public LogIn()
        {
            InitializeComponent();
            //IContainerExtension container, IRegionManager regionManager
            //_container = container;
            //_regionManager = regionManager;
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //var viewModel = new LogInViewModel();
                //viewModel.SignIn += OnLoginSuccess;
               // DataContext = viewModel;
            }
          
        }
        private void OnLoginSuccess()
        {
            var mainWindow = _container.Resolve<MainWindow>();
            RegionManager.SetRegionManager(mainWindow, _regionManager);
            mainWindow.Show();
           // Close();
        }
    }
}
