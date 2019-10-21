using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KeepaModule.Converters
{
    public class DictionaryValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            string val = (string)value;
            //System.Windows.MessageBox.Show("Convert Method Value: "+val);
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var key = (KeyValuePair<string, string>)value;
            var stringKey = key.Value;
            //System.Windows.MessageBox.Show("ConvertBack Method Value:" + stringKey);
            return stringKey;
        }
    }
}
