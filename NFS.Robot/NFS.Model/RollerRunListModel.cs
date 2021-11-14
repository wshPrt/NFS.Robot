using Prism.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Model
{
    /// <summary>
    /// 输送机分析-托辊运行列表
    /// </summary>
    public class RollerRunListModel : BindableBase
    {
        /// <summary>
        /// 总行数
        /// </summary>
        private int totalRow;
        public int TotalRow
        {
            get { return totalRow; }
            set { totalRow = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        private int totalPage;
        public int TotalPage
        {
            get { return totalPage; }
            set { totalPage = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 页大小
        /// </summary>
        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 页
        /// </summary>
        private int page;
        public int Page
        {
            get { return page; }
            set { page = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 本年度运行时间
        /// </summary>
        private int yearRun;
        public int YearRun
        {
            get { return yearRun; }
            set { yearRun = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 本月运行时间
        /// </summary>
        private int monthRun;
        public int MonthRun
        {
            get { return monthRun; }
            set { monthRun = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// ID
        /// </summary>
        private int Id;
        public int id
        {
            get { return Id; }
            set { Id = value; RaisePropertyChanged();}
        }

        /// <summary>
        /// 合计运行时间
        /// </summary>
        private int totalRun;
        public int TotalRun
        {
            get { return totalRun; }
            set { totalRun = value; RaisePropertyChanged();}
        }

        public class List
        {
            /// <summary>
            /// 本年度运行时间
            /// </summary>
            public int year_run { get; set; }
            /// <summary>
            /// 本月运行时间
            /// </summary>
            public int month_run { get; set; }
            /// <summary>
            /// Id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 合计运行时间
            /// </summary>
            public int total_run { get; set; }
        }

        public class PageInfo
        {
            /// <summary>
            /// 总行
            /// </summary>
            public int totalRow { get; set; }
            /// <summary>
            /// 总页
            /// </summary>
            public int totalPage { get; set; }
            /// <summary>
            /// 页大小
            /// </summary>
            public int pageSize { get; set; }
            /// <summary>
            /// 页
            /// </summary>
            public int page { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<List> list { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 读取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public PageInfo pageInfo { get; set; }
        }

    }
}
