using LibVLCSharp.Shared;
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

namespace NFS.Robot.VLCPlayer
{
    /// <summary>
    /// VLCPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class VLCPlayer : UserControl
    {
        string strURL;
        readonly LibVLC _libvlc;
        public VLCPlayer(string url)
        {
            this.strURL = url;
            InitializeComponent();
            Core.Initialize();
            _libvlc = new LibVLC();
            VideoView0.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libvlc);
            var m = new Media(_libvlc, this.strURL, FromType.FromLocation);
            //设置相应的参数，播放rtsp流
            m.AddOption(":rtsp-tcp");
            m.AddOption(":clock-synchro=0");
            m.AddOption(":live-caching=0");
            m.AddOption(":network-caching=100");
            m.AddOption(":file-caching=0");
            m.AddOption(":grayscale");
            VideoView0.MediaPlayer.Play(m);
        }
    }
}
