using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model.Line
{
    /// <summary>
    /// 获取线路列表(精简)
    /// </summary>
    public class SimplifyLineListModel:BindableBase
    {
        /// <summary>
        /// 线路Id
        /// </summary>
        private int _lineId;
        public int LineId 
        {
            get { return _lineId; }
            set
            {
                _lineId = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 线路名称
        /// </summary>
        private string _lineName;
        public string LineName
        {
            get { return _lineName; }
            set 
            {
                _lineName = value;
                RaisePropertyChanged();
            }
        }



        public class Data
        {
            /// <summary>
            /// 线路ID
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 线路名称
            /// </summary>
            public string lineName { get; set; }
        }
        public class Root
        {
            /// <summary>
            /// 读取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 线路编号
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Data> data { get; set; }
        }
    }
}
