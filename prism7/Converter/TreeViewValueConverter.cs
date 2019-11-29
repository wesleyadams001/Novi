using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prism7.Converter
{
    /// <summary>
    /// Converter for the main tree view
    /// </summary>
    public class TreeViewValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value== null)
            {
                return Binding.DoNothing;
            }
            return (string)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            return value;
        }
    }
}
