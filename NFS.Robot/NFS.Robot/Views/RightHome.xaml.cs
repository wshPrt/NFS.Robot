using Microsoft.Extensions.Logging;
using NFS.Commons;
using NFS.Commons.Controls;
using NFS.Model;
using NFS.Robot.Resource.CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

namespace NFS.Robot.Views
{
    /// <summary>
    /// RightHome.xaml 的交互逻辑
    /// </summary>
    public partial class RightHome : UserControl
    {
        string urlTwo = Urls.RETURN_TRIP;
        public RightHome()
        {
            InitializeComponent();
            this.Loaded += RightHome_Loaded;
        }

        private async void RightHome_Loaded(object sender, RoutedEventArgs e)
        {
            //await Task.Delay(1000);
            //meFire.Visibility = Visibility.Visible;
            //var mp4Path = AppDomain.CurrentDomain.BaseDirectory + @"robot.mp4";
            //meFire.Source = new Uri(mp4Path, UriKind.RelativeOrAbsolute);
            //meFire.Position = TimeSpan.Zero;
            //meFire.Play();

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

        private void meFire_MediaEnded(object sender, RoutedEventArgs e)
        {
            //meFire.Visibility = Visibility.Visible;
            //var mp4Path = AppDomain.CurrentDomain.BaseDirectory + @"robot.mp4";
            //meFire.Source = new Uri(mp4Path, UriKind.RelativeOrAbsolute);
            //meFire.Position = TimeSpan.Zero;
            //meFire.Play();
        }
        private int i = 0;
        private List<RealTimeWacthModel> modelList = new List<RealTimeWacthModel>();
        private async void Border2_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                if (modelList.Count != 0)
                {
                    urlTwo = modelList[i].url;
                }

                Dispatcher.BeginInvoke(new Action(delegate
                {
                    VLCPlayer.VLCPlayer player = new VLCPlayer.VLCPlayer(urlTwo);
                    //this.Image2.Children.Add(player);
                }));
            });
        }

    }
}
