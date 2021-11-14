using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using NFS.Robot.Resource.Dialog;
using NFS.Robot.Themes;
using Prism.Regions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NFS.Robot.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager,Logger<MainWindow> logger)
        {
            
            InitializeComponent();
            var log = logger;
            log.LogInformation("NFS.Robot日志信息");
            //为界面元素注册区域
            RegionManager.SetRegionName(Right, "RightRegion");
            //为指定区域指定页面
            regionManager.RegisterViewWithRegion("RightRegion", typeof(RightHome));
            regionManager.RegisterViewWithRegion("RegionContent", typeof(Accueil));
            regionManager.RegisterViewWithRegion("LeftRegion", typeof(LeftHome));

            btnClose.Click += async (s, e) =>
            {
                this.Close();
                Process.GetCurrentProcess().Kill();
            };
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            }));
        }

        /// <summary>
        /// 机器人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRobot_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
        }

        private void btnConveyor_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }

        private void btnDataCenter_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnUserCenter.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrontPage_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 1);
            gdContent.SetValue(Grid.RowProperty, 1);
        }
        /// <summary>
        /// 实时位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
        }

        private void btnRoller_Click(object sender, RoutedEventArgs e)
        {
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
        }

        private void btnRollerAnalyze_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }

        private void btnEnvironment_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }

        private void btnPolicySetting_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }

        private void btnMaintainRecord_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
        }

        private void btnEnvironmentData_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnConveyor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
        }

        private void btnFullScreenVideo_Click(object sender, RoutedEventArgs e)
        {
            //gdContent.SetValue(Grid.ColumnProperty, 0);
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 0);
        }

        private void btnUserCenter_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 0);
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnUserCenter.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
        }

        private void btnNoiseAnalysis_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            
        }

        private void btnRobotVibration_Click(object sender, RoutedEventArgs e)
        {
            gdContent.SetValue(Grid.ColumnSpanProperty, 2);
            gdContent.SetValue(Grid.RowProperty, 1);
            btnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnNoiseAnalysis.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnMaintainRecord.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            btnRobotVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
        }
    }
}
