using NFS.Model.Home;
using NFS.Robot.Interface;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NFS.Robot.ViewModels
{
   public class FullScreenVideoViewModel: BindableBase
    {
        public FullScreenVideoViewModel() 
        {
            RouteFormList = new ObservableCollection<RouteFormModel>();
            //InitRoute();
        }

        #region 路线(下拉框)
        private ObservableCollection<RouteFormModel> _routeFormList;
        public ObservableCollection<RouteFormModel> RouteFormList
        {
            get { return _routeFormList; }
            set { _routeFormList = value; }
        }

        /// <summary>
        /// 路线列表
        /// </summary>
        private async void InitRoute() 
        {
           await Task.Run(() =>
            {
                IRouteListForm form = new IRouteListForm();
                var result = form.RouteListForm().Result;
                string success = result.msg;
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (success == "success")
                    {
                        for (int i = 0; i < result.list.Count; i++)
                        {
                            RouteFormList.Add(new RouteFormModel()
                            {
                                Id = result.list[i].id,
                                LineName = result.list[i].line_name
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show(success);
                    }
                }));
            });
        }
        #endregion
    }
}
