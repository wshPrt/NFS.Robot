using NFS.Robot.Themes.RobotState;
using Prism.Regions;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NFS.Robot.Views
{
    /// <summary>
    /// ConveyorAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class ConveyorAnalysis : UserControl
    {
        public ConveyorAnalysis(IRegionManager regionManager)
        {
            InitializeComponent();

            RegionManager.SetRegionName(ctrRun,"RegionRun");
            RegionManager.SetRegionName(ctrStandby, "RegionStandby");
            RegionManager.SetRegionName(ctrDowntime, "RegionDowntime");
            RegionManager.SetRegionName(ctrAbnormal, "RegionAbnormal");
            RegionManager.SetRegionName(RunTrend, "RunTrendRegion");

            //为指定区域指定页面
            regionManager.RegisterViewWithRegion("RegionRun", typeof(RunStyle));
            regionManager.RegisterViewWithRegion("RegionStandby", typeof(StandbyStyle));
            regionManager.RegisterViewWithRegion("RegionDowntime", typeof(DowntimeStyle));
            regionManager.RegisterViewWithRegion("RegionAbnormal", typeof(AbnormalStyle));
            regionManager.RegisterViewWithRegion("RunTrendRegion", typeof(RunTrend));
        }
    }
}
