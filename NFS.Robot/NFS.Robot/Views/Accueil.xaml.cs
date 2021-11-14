using LiveCharts;
using LiveCharts.Wpf;
using NFS.Commons;
using NFS.Model;
using NFS.Robot.Themes;
using Prism.Ioc;
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
    /// Accueil.xaml 的交互逻辑
    /// </summary>
    public partial class Accueil : UserControl
    {
        string url = Urls.FRONT_LIGHT_URL;
        string urlTwo = Urls.INFRARED_URL;
        private List<RealTimeWacthModel> modelList = new List<RealTimeWacthModel>();
        private int i = 0;
        public Accueil()
        {
            InitializeComponent();
        }

        private async void Border_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                if (modelList.Count != 0)
                {
                    url = modelList[i].url;
                }
    
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    //VLCPlayer.VLCPlayer player = new VLCPlayer.VLCPlayer(url);
                    //this.Image1.Children.Add(player);
                }));
            });
        }

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
                    //VLCPlayer.VLCPlayer player = new VLCPlayer.VLCPlayer(urlTwo);
                    //this.Image2.Children.Add(player);
                }));
            });
        }
    }
}
