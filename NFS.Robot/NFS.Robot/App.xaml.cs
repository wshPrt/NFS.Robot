using NFS.Robot.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using NFS.Commons;
using Prism.Regions;
using Prism.DryIoc;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NFS.Robot.Themes;
using NFS.Robot.ViewModels;
using NFS.Robot.Resource.Dialog;
using NFS.Robot.Themes.Styles;
using DryIoc.Microsoft.DependencyInjection;
using Prism.Services.Dialogs;
using System;

namespace NFS.Robot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            // return Container.Resolve<MainWindow>();
            try
            {
                var mw = Container.Resolve<MainWindow>();
                var win = Container.Resolve<LogIn>();
                var a = win.ShowDialog();
                if (a.HasValue && a.Value)
                {
                   return mw;
                }
                return win;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LogIn>();
            containerRegistry.RegisterForNavigation<Accueil>();
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Robots>();
            containerRegistry.RegisterForNavigation<PolicySetting>();
            containerRegistry.RegisterForNavigation<DataCenter>();
            containerRegistry.RegisterForNavigation<ClockStyle>();
            containerRegistry.RegisterForNavigation<Location>();
            containerRegistry.RegisterForNavigation<PTZVideo>();
            containerRegistry.RegisterForNavigation<UserControl1>();
            containerRegistry.RegisterForNavigation<RollerTemperature>();
            containerRegistry.RegisterForNavigation<ConveyorAnalysis>();
            containerRegistry.RegisterForNavigation<RollerAnalysis>();
            containerRegistry.RegisterForNavigation<EnvironmentalAnalysis>();
            containerRegistry.RegisterForNavigation<MaintainRecord>();
            containerRegistry.RegisterForNavigation<EnvironmentData>();
            containerRegistry.RegisterForNavigation<FullScreenVideo>();
            containerRegistry.RegisterForNavigation<UserManage>();
            containerRegistry.RegisterForNavigation<RobotVibration>();
            containerRegistry.RegisterForNavigation<NoiseAnalysis>();
            //弹窗遮罩
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            containerRegistry.RegisterForNavigation<ModifyTactics>();
            containerRegistry.RegisterDialog<ModifyTactics, ModifyTacticsViewModel>();
            containerRegistry.RegisterForNavigation<AddTactics>();
            containerRegistry.RegisterDialog<AddTactics, AddTacticsViewModel>();
            containerRegistry.RegisterForNavigation<MsgView>();
            containerRegistry.RegisterDialog<MsgView, MsgViewModel>();
            containerRegistry.RegisterForNavigation<RollerDetail>();
            containerRegistry.RegisterDialog<RollerDetail, RollerDetailViewModel>();
            containerRegistry.RegisterForNavigation<RollerRemarks>();
            containerRegistry.RegisterDialog<RollerRemarks, RollerRemarksViewModel>();
            containerRegistry.RegisterForNavigation<RollerRemarkDetails>();
            containerRegistry.RegisterDialog<RollerRemarkDetails, RollerRemarkDetailsViewModel>();
            containerRegistry.RegisterForNavigation<RollerMaintenance>();
            containerRegistry.RegisterDialog<RollerMaintenance, RollerMaintenanceViewModel>();
            containerRegistry.RegisterForNavigation<ConveyorOverhaul>();
            containerRegistry.RegisterDialog<ConveyorOverhaul, ConveyorOverhaulViewModel>();
            containerRegistry.RegisterForNavigation<AddRecord>();
            containerRegistry.RegisterDialog<AddRecord, AddRecordViewModel>();
            containerRegistry.RegisterForNavigation<MaintainDetails>();
            containerRegistry.RegisterDialog<MaintainDetails, MaintainDetailsViewModel>();
            containerRegistry.RegisterForNavigation<ModifyPassword>();
            containerRegistry.RegisterDialog<ModifyPassword, ModifyPasswordViewModel>();
        }

        //日志集成
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollention = new ServiceCollection();
            serviceCollention.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.SetMinimumLevel(LogLevel.Trace);
                configure.AddNLog();
            });

            return new DryIocContainerExtension(new Container(CreateContainerRules()).
                    WithDependencyInjectionAdapter(serviceCollention));
        }
    }
}
