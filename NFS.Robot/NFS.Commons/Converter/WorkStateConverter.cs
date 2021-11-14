using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NFS.Commons.Converter
{
    public class WorkStateConverter : IValueConverter
    {
        //"workState":1, // 工作状态，1 充电中，2待命中，3巡检中，4已关机
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result > 0)
                {
                    if (result.Equals(1))
                    {
                        return "充电中";
                    }
                    else if (result.Equals(2))
                    {
                        return "待命中";
                    }
                    else if (result.Equals(3))
                    {
                        return "巡检中";
                    }
                    else
                    {
                        return "已关机";
                    }
                }
            }
            return "离线";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
