using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PicDB.Wpf
{
    class NumberToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) == 0)
            {
                return "";
            }
            else
            {
                return value?.ToString() ?? "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (int.TryParse(value.ToString(), out int res))
            {
                return res;
            }

            return 0;
        }
    }
}
