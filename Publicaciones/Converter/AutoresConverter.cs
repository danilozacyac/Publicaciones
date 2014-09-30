using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Publicaciones.Dao;

namespace Publicaciones.Converter
{
    public class AutoresConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                ObservableCollection<Autores> autores = value as ObservableCollection<Autores>;

                string autoresStr = "";

                foreach (Autores autor in autores)
                {
                    autoresStr += autor.Nombre + ", ";
                }

                return autoresStr;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
