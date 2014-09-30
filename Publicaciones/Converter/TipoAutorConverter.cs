using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace Publicaciones.Converter
{
    public class TipoAutorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int estadoTesis = value as int? ?? 0;

            switch (estadoTesis)
            {
                case 1: return new SolidColorBrush(Colors.LightBlue);
                case 2: return new SolidColorBrush(Colors.LightCyan);
                case 3: return new SolidColorBrush(Colors.LightGreen);
                case 4: return new SolidColorBrush(Colors.LightPink);
                case 5: return new SolidColorBrush(Colors.Yellow);
                default: return new SolidColorBrush(Colors.White);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
