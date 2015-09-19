using System;
using System.Globalization;
using System.Windows.Data;

namespace IstarWindows.Code
{
    public class NullableConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // if the value is null, there is nothing to convert
            // we want the empty string to be interpretted as null
            // Now let the builtin conversion handle the real conversion
            return string.IsNullOrEmpty(value?.ToString()) ? null : value;
        }

        #endregion
    }
}
