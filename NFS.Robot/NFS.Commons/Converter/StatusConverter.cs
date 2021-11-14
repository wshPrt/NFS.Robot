using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NFS.Commons.Converter
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result > 0)
                {
                    if (result.Equals(1))
                    {
                        return "正常";
                    }
                    else
                    {
                        return "故障";
                    }
                }
                else
                {
                    return "停用";
                }
            }
            return "停用";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
