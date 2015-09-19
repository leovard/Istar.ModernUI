using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IstarWindows.Code
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var dateValue = (DateTime)value;
            if (SimulateIsDate.IsDate(dateValue))
            {
                return dateValue.Equals(DateTime.MinValue)
                    ? DateTime.Today.ToShortDateString()
                    : dateValue.ToShortDateString();
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null || value == DependencyProperty.UnsetValue)
            {
                value = DateTime.Today.ToShortDateString();
            }
            return value;
        }

    }

    public static class SimulateIsDate
    {
        public static bool IsDate(object expression)
        {
            if (expression == null)
                return false;

            DateTime testDate;
            return DateTime.TryParse(expression.ToString(), out testDate);
        }
    }
}
