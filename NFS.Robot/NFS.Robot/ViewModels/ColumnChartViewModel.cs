using NFS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Robot.ViewModels
{
    public class ColumnChartViewModel
    {
        public ColumnChartViewModel()
        {
            this.SneakersDetail = new ObservableCollection<ColumnChartModel>();
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Adidas", ItemsCount = 25 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Nike", ItemsCount = 17 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Reebok", ItemsCount = 30 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Fila", ItemsCount = 18 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Puma", ItemsCount = 10 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "TATA", ItemsCount = 21 });
        }

        public ObservableCollection<ColumnChartModel> SneakersDetail { get; set; }
    }
}
