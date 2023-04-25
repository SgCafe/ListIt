using System;
using System.Globalization;
using Xamarin.Forms;

namespace ListIt.Converters
{
    internal class ConverterToBgColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = $"{value}";
            if (!string.IsNullOrEmpty(text))
            {
                if (text == "Mercado")
                {
                    return "#FDFFE1";
                }
                else if (text == "Eletronicos")
                {
                    return "#CEEADC";
                }
                else if (text == "Oficina")
                {
                    return "#FFCEA1";
                }
                else if (text == "Farmácia")
                {
                    return "#FFDACF";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}