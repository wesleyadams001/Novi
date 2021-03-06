﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prism7.Converter
{
    /// <summary>
    /// Converter to interact with dictionary values
    /// </summary>
    public class DictionaryValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            string val = (string)value;
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var key = (KeyValuePair<string, string>)value;
            return key;
        }
    }
}
