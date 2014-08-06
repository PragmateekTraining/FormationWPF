using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataBinding
{
    public class SpreadConverter : IValueConverter
    {
        public long? Max { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long? reference = parameter != null ? System.Convert.ToInt64(parameter) : Max;

            if (reference == null)
                return DependencyProperty.UnsetValue;

            return reference - System.Convert.ToInt64(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
