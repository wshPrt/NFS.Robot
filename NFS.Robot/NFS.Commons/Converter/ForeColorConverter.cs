using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NFS.Commons.Converter
{
    [ValueConversion(typeof(int), typeof(string))]
    public class ForeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value == null)
            //    throw new ArgumentNullException("value can not be null");

            //int index = System.Convert.ToInt32(value);
            //if (index == 1)
            //    return "Blue";
            //else if (index == 2)
            //    return "Red";
            //else
            //    return "Green";
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                if (result)
                    return "Blue";
                else
                    return "Green";
            }
            return "Blue";
        }

        //目标属性传给源属性时，调用此方法ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
