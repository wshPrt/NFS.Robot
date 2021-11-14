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
    /// AddTactics.xaml 的交互逻辑
    /// </summary>
    public partial class AddTactics : UserControl
    {
        public AddTactics()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 每周
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbWeekly_Click(object sender, RoutedEventArgs e)
        {
            spWeekly.Visibility = Visibility.Visible;
            lstMinus.Visibility = Visibility.Visible;
            spInspection.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 每天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbEveryday_Click(object sender, RoutedEventArgs e)
        {
            //spStartEnd.SetValue(Grid.RowProperty,5);
            //spInspection.SetValue(Grid.RowProperty,3);
            //spStartEnd.SetValue(Grid.RowProperty, 4);
            //rbEveryday.SetValue(Grid.RowProperty, 3);
            //rbWeekly.SetValue(Grid.RowProperty, 3);
            spWeekly.Visibility = Visibility.Hidden;
            lstMinus.Visibility = Visibility.Hidden;

        }
    }
}
