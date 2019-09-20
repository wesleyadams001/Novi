using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prism7.Converter
{
    public class EncryptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (bool)value;
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var x = (bool)value;
            var val2 = false;
            var strPar = (string)parameter;
            int par = int.Parse(strPar);
            switch (par)
            {
                case 1:
                    val2 = true;
                    break;
                case 0:
                    val2 = false;
                    break;

            }
            if(val2 != x)
            {
                return false;
            }
            else
            {
                return true;
            }
           
           
        }
    }
}
