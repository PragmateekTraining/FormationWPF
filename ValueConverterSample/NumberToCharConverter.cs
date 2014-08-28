using System;
using System.Windows.Data;

namespace ValueConverterSample
{
    public class NumberToCharConverter : IValueConverter
    {
        public char? Character { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string parameterAsString = parameter as string;

            char? localValue = parameterAsString != null && parameterAsString.Length >= 1 ? parameterAsString[0] : null as char?;

            char character = localValue ?? Character ?? '*';

            int number = System.Convert.ToInt32(value);

            return new string(character, number);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;

            return s.Length;
        }
    }
}
