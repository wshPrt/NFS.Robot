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
    /// ConveyorOverhaul.xaml 的交互逻辑
    /// </summary>
    public partial class ConveyorOverhaul : UserControl
    {
        public ConveyorOverhaul()
        {
            InitializeComponent();
            this.txtImportantMsg.Text = "机架、输送带、传动滚筒、改装滚筒、托辊、驱动装置等";
            this.txtRecommendMsg.Text = "1.托辊R00001,一号线路500m处,经常超温,上次超温时间"
               + "\r\n"
               + "2021-09-17,本周已连续两次超温报警,已有损坏,建议更换......";
        }
    }
}
