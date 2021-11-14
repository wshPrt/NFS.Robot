using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Home
{
    public class RouteFormModel : BindableBase
    {
        /// <summary>
        /// 路线ID
        /// </summary>
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 路线名称
        /// </summary>
        private string lineName;
        public string LineName
        {
            get { return lineName; }
            set { lineName = value; RaisePropertyChanged(); }
        }


        #region
        public class List
        {
            /// <summary>
            /// 一号路线
            /// </summary>
            public string line_name { get; set; }
            /// <summary>
            /// 线路ID
            /// </summary>
            public int id { get; set; }
        }

        public class Root
        {
            /// <summary>
            ///  success
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 1表示PC端
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<List> list { get; set; }
        }
        #endregion
    }
}
