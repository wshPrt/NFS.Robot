using MaterialDesignThemes.Wpf;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// PTZVideo.xaml 的交互逻辑
    /// </summary>
    public partial class PTZVideo : UserControl
    {
        public PTZVideo()
        {
            InitializeComponent();
        }

        private void btnFocus_Click(object sender, RoutedEventArgs e)
        {
            focusPop.IsOpen = true;
        }

        private void btnVolume_Click(object sender, RoutedEventArgs e)
        {
            volumePop.IsOpen = true;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (btnPlay.ToolTip.ToString() != "暂停")
            {
                btnPlay.ToolTip = "暂停";
                btnIcon.Kind = (PackIconKind)4539;
            }
            else 
            {
                btnPlay.ToolTip = "播放";
                btnIcon.Kind = (PackIconKind)4678;
            }
        }

        private void btnEnlarge_Click(object sender, RoutedEventArgs e)
        {
            if(btnEnlarge.ToolTip.ToString() != "放大") 
            {
                btnEnlarge.ToolTip = "放大";
                // ArrowTopLeftBottomRight
                btnIcons.Kind = (PackIconKind)491;
            }
            else 
            {
                btnEnlarge.ToolTip = "缩小";
                btnIcons.Kind = (PackIconKind)460;
            }
        }

       
    }
}
