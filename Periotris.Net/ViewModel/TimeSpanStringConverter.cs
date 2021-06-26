using System;
using System.Globalization;
using System.Windows.Data;

namespace Periotris.Net.ViewModel
{
    public class TimeSpanStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "--:--";
            }

            if (value is TimeSpan realVal)
            {
                return $"{realVal.Minutes:D2}:{realVal.Seconds:D2}";
            }

            throw new ArgumentException(null, nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Two-way binding is not supported on " +
                                            nameof(TimeSpanStringConverter));
        }
    }
}