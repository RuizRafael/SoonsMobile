using Soons.Models;
using Soons.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Soons.Converters
{
    public class ConvertToCantidad : IValueConverter
    {

        public object Convert(object value, Type targetType
        , object parameter, CultureInfo culture)
        {
            //VALUE: El valor enlazado en el Binding
            //TargetType: El tipo de objeto enlazado
            //Parameter: Parametros asociados al binding
            //Culture: El tipo de cultura actual de la App
            if (value != null)
            {
                List<Prod> prod = new List<Prod>(value as IEnumerable<Prod>);
                return prod.Count;
            }
            else
            {
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
