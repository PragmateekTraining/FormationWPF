using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace MultiBindingSample
{
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ChangeType(values.Sum(v => System.Convert.ToDecimal(string.IsNullOrWhiteSpace(v.ToString()) ? 0 : v)), targetType);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
