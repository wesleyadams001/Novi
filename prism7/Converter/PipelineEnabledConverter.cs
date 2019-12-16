using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prism7.Converter
{
    public class PipelineEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool newValue = false;
            if ( value != null)
            {
                
                newValue = (bool)value;
                if (newValue == false)
                {
                    newValue = true;
                }
                else
                {
                    newValue = false;
                }
                return newValue;
            }
            return newValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
