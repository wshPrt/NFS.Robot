using NFS.Robot.Resource.CefSharp;
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
    /// Location.xaml 的交互逻辑
    /// </summary>
    public partial class Location : UserControl
    {
        public Location()
        {
            InitializeComponent();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 加载html文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Location_Loaded(object sender, RoutedEventArgs e)
        {
           await Task.Run(() =>
            {
                App.Current.Dispatcher.InvokeAsync((Action)(() =>
                {
                    string url = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"), "Map.html");
                    web.Address = "file:///" + url;
                    web.LifeSpanHandler = new CefLifeSpanHandler();
                }));

            });

        }

        /// <summary>
        /// 销毁 ChromiumWebBrowser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Location_Unloaded(object sender, RoutedEventArgs e)
        {
            //if (!web.IsDisposed)
            //{
            //    web.GetBrowser().CloseBrowser(false);
            //    web.Dispose();
            //}
        }

        private void btnModifyStrategy_Click(object sender, RoutedEventArgs e)
        {
            //MainWindowbtnPolicySetting.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            //btnLocation.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF45B9BF"));
            //btnRoller.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            //btnRollerAnalyze.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            //btnEnvironmentData.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }
    }
}
