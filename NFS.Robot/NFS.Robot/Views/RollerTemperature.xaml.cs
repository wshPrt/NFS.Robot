using NFS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// RollerTemperature.xaml 的交互逻辑
    /// </summary>
    public partial class RollerTemperature : UserControl
    {
        public static RollerTemperature Instance;
        public RollerTemperature()
        {
            InitializeComponent();
            //Instance = this;
            //Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
        }

        private void DeviceEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeviceDel_Click(object sender, RoutedEventArgs e)
        {

        }
        //#region 托辊损坏区段分析 柱状图
        //private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        //{
        //    RollerModel.Instance.PropertyChanged -= Instance_PropertyChanged;
        //}
        //private void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(new Action(delegate
        //    {
        //        var model = (RollerModel)sender;
        //        if (e.PropertyName == "RollerNumber")
        //            SetBypoints(model.RollerNumber);
        //        else if (e.PropertyName == "ErorrRollerNumber")
        //            SetSypoints(model.ErorrRollerNumber);
        //        else if (e.PropertyName == "XSection")
        //            SetSectionX(model.XSection);
        //        else if (e.PropertyName == "TotalNumber")
        //            SetY(model.TotalNumber);
        //    }));
        //}
        //public void SetBypoints(int[] values)
        //{
        //    Dispatcher.BeginInvoke(new Action(delegate
        //    {
        //       // bypoints.Values = new LiveCharts.ChartValues<int>(values);
        //    }));
        //}
        //public void SetSypoints(int[] values)
        //{
        //    Dispatcher.BeginInvoke(new Action(delegate
        //    {
        //        sypoints.Values = new LiveCharts.ChartValues<int>(values);
        //    }));
        //}
        //public void SetSectionX(string[] values)
        //{
        //    Dispatcher.BeginInvoke(new Action(delegate
        //    {
        //        shlabels.Labels = values;// new LiveCharts.ChartValues<string[]>(values);
        //    }));
        //}
        //public void SetY(int values)
        //{
        //    Dispatcher.BeginInvoke(new Action(delegate
        //    {
        //        Y.MinValue = 0;
        //        Y.MaxValue = values;// new LiveCharts.ChartValues<int>(values);
        //    }));
        //}
        //#endregion
    }
}
