using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace DataTemplateSelectorSample
{
    public class ExtractFileConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Path.GetFileName((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
