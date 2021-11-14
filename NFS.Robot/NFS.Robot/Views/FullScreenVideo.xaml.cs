using Microsoft.Maps.MapControl.WPF;
using NFS.Robot.Resource.CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// FullScreenVideo.xaml 的交互逻辑
    /// </summary>
    public partial class FullScreenVideo : UserControl
    {
        public FullScreenVideo()
        {
            InitializeComponent();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 加载html文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullScreenVideo_Loaded(object sender, RoutedEventArgs e)
        {
            //web.BringToFront();
            App.Current.Dispatcher.InvokeAsync((Action)(() =>
            {
                string url = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"), "Map.html");
                web.Address = "file:///" + url;
                web.LifeSpanHandler = new CefLifeSpanHandler();
            }));
        }

        /// <summary>
        /// 销毁 ChromiumWebBrowser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullScreenVideo_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!web.IsDisposed)
            {
                web.GetBrowser().CloseBrowser(false);
                web.Dispose();
            }
        }
    }
}
    //public class CustomTileSource : TileSource
    //{
    //    readonly string UrlFormat = "http://localhost:8844/{0}/{1}/{2}/{3}";
    //    //  readonly int DbId = GMapProviders.OpenStreetMap.DbId;

    //    // keep in mind that bing only supports mercator based maps

    //    public override Uri GetUri(int x, int y, int zoomLevel)
    //    {
    //        return new Uri(string.Format(UrlFormat, null, zoomLevel, x, y));
    //    }
    //}
    //public class CustomTileLayer : MapTileLayer
    //{
    //    public CustomTileLayer()
    //    {
    //        TileSource = new CustomTileSource();
    //    }
    //}
