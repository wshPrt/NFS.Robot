using MaterialDesignThemes.Wpf;
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

namespace NFS.Robot.Views
{
    /// <summary>
    /// ConveyorAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class PolicySetting : UserControl
    {
        public PolicySetting()
        {
            InitializeComponent();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddInspection_Click(object sender, RoutedEventArgs e)
        {
            MessageTips("请确认", sender, e);
        }
        public async void MessageTips(string message, object sender, RoutedEventArgs e)
        {
            if (sender.ToString().Contains("添加巡检策略"))
            {
                var sampleMessageDialog = new ModifyTactics
                {
                    Message = message
                };
                await DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
        }
   }
}
