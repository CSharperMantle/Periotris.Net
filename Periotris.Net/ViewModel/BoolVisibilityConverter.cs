using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Periotris.Net.ViewModel
{
    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility v && v == Visibility.Visible)
            {
                return true;
            }

            return false;
        }
    }
}