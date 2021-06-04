using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Soons.Converters
{
    public class ConvertState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int nume =(int)value;
            if (value != null)
            {
                if (nume == 0) return "preparado.png";
                else if (nume == 1) return "pagado.png";
                else if (nume == 2) return "empaquetado.png";
                else if (nume == 3) return "repato.png";
                else if (nume == 4) return "si.png";
            }
            return "Sin estado";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
