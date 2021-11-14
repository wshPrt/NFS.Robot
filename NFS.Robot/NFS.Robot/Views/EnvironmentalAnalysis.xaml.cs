using NFS.Robot.Resource.CefSharp;
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
    /// EnvironmentalAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class EnvironmentalAnalysis : UserControl
    {
        public EnvironmentalAnalysis(IRegionManager regionManager)
        {
            InitializeComponent();
            RegionManager.SetRegionName(ctrIndex, "RegionIndex");

            //为指定区域指定页面
            regionManager.RegisterViewWithRegion("RegionIndex", typeof(QualityIndexStyle));            
        }

        /// <summary>
        /// 环境数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnvironmentalAnalysis_Loaded(object sender, RoutedEventArgs e)
        {
            //App.Current.Dispatcher.InvokeAsync((Action)(() =>
            //{
            //    string url = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"), "HeatMap.html");
            //    cwbEnvironmental.Address = "file:///" + url;
            //    cwbEnvironmental.LifeSpanHandler = new CefLifeSpanHandler();
            //}));
        }

        /// <summary>
        /// 销毁 ChromiumWebBrowser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnvironmentalAnalysis_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!cwbEnvironmental.IsDisposed)
            {
                cwbEnvironmental.GetBrowser().CloseBrowser(false);
                cwbEnvironmental.Dispose();
            }
        }

        /// <summary>
        /// 温度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnTemperature_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            await Task.Run(() =>
            {
                App.Current.Dispatcher.InvokeAsync((Action)(() =>
                {
                   string url = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"), "HeatMap.html");
                    cwbEnvironmental.Address = "file:///" + url;
                    cwbEnvironmental.LifeSpanHandler = new CefLifeSpanHandler();
                }));
            });

        }
        /// <summary>
        /// 湿度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHumidity_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));

        }

        /// <summary>
        /// 粉尘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDust_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
        }

        /// <summary>
        /// 一氧化碳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCo_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
        }

        /// <summary>
        /// 噪声
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoise_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
        }

        /// <summary>
        /// 振动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVibration_Click(object sender, RoutedEventArgs e)
        {
            phTemperature.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtTemperature.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phHumidity.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtHumidity.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phDust.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtDust.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phCo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtCo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phNoise.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            txtNoise.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF787878"));
            phVibration.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            txtVibration.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
        }
    }
}
