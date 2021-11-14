using NFS.Robot.Themes;
using NFS.Robot.Themes.Styles;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WebSocketSharp;

namespace NFS.Robot.Views
{
    /// <summary>
    /// LeftHome.xaml 的交互逻辑
    /// </summary>
    public partial class LeftHome : UserControl
    {
        public LeftHome(IRegionManager regionManager)
        {
            InitializeComponent();
            //为界面元素注册区域
            RegionManager.SetRegionName(CtrSpeed, "RegionSpeed");
            RegionManager.SetRegionName(CtrElectricity, "RegionElectricity");
            RegionManager.SetRegionName(CtrRobotSpeed, "RegionRobotSpeed");
            RegionManager.SetRegionName(CtrMileage, "RegionMileage");

            RegionManager.SetRegionName(Rel, "RelRegion");
            RegionManager.SetRegionName(Angle, "AngleRegion");
            RegionManager.SetRegionName(MilageTime, "MilageTimeRegion");
            RegionManager.SetRegionName(MileageMiles, "MileageMilesRegion");
            
            //为指定区域指定页面
            regionManager.RegisterViewWithRegion("RegionSpeed", typeof(ClockStyle));
            regionManager.RegisterViewWithRegion("RegionElectricity", typeof(ElectricityStyle));
            regionManager.RegisterViewWithRegion("RegionRobotSpeed", typeof(SpeedStyle));
            regionManager.RegisterViewWithRegion("RegionMileage", typeof(MileageStyle));

            regionManager.RegisterViewWithRegion("RelRegion", typeof(RelStyle));
            regionManager.RegisterViewWithRegion("AngleRegion", typeof(HorizontalAngleStyle));
            regionManager.RegisterViewWithRegion("MilageTimeRegion", typeof(MilageTimeStyle));
            regionManager.RegisterViewWithRegion("MileageMilesRegion", typeof(MileageMilesStyle));

            var mp3Path = AppDomain.CurrentDomain.BaseDirectory + @"warning.mp3";
            warningMp3.Source = new Uri(mp3Path,UriKind.RelativeOrAbsolute);
           // warningMp3.Play();
            this.Loaded += LeftHome_Loaded;
        }

        private async void LeftHome_Loaded(object sender, RoutedEventArgs e)
        {
            ImageAlarm.Visibility = Visibility.Visible;
            ImageMonitor.Visibility = Visibility.Collapsed;
            await Task.Delay(1000);
            ImageAlarm.Visibility = Visibility.Collapsed;
            ImageMonitor.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// 切换MP4视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private async void LeftHome_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //meFire.Visibility = Visibility.Collapsed;
        //    ////ImageIndex.Visibility = Visibility.Visible;

        //    //await Task.Delay(1000);

        //    ////ImageIndex.Visibility = Visibility.Collapsed;
        //    //meFire.Visibility = Visibility.Visible;
        //    //var mp4Path = AppDomain.CurrentDomain.BaseDirectory + @"smokeAlarm.mp4";
        //    //meFire.Source = new Uri(mp4Path,UriKind.RelativeOrAbsolute);
        //    //meFire.Position = TimeSpan.Zero;
        //    //meFire.Play();
        //}

        private void btnPTZ_Click(object sender, RoutedEventArgs e)
        {
            //gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            //gdContent.SetValue(Grid.RowProperty, 1);
        }

        private void btnEnlarge_Click(object sender, RoutedEventArgs e)
        {
            //Zoom zoom = new Zoom();
            //zoom.ShowDialog();
        }

        //private async void meFire_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    //meFire.Visibility = Visibility.Collapsed;
        //    ////ImageIndex.Visibility = Visibility.Visible;

        //    //await Task.Delay(1000);

        //    ////ImageIndex.Visibility = Visibility.Collapsed;
        //    //meFire.Visibility = Visibility.Visible;
        //    //var mp4Path = AppDomain.CurrentDomain.BaseDirectory + @"smokeAlarm.mp4";
        //    //meFire.Source = new Uri(mp4Path, UriKind.RelativeOrAbsolute);
        //    //meFire.Position = TimeSpan.Zero;
        //    //meFire.Play();
        //}
    }
}
