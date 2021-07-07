/*
 * Periotris.Net
 * Copyright (C) 2020-present Rong "Mantle" Bao (CSharperMantle)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see < https://github.com/CSharperMantle/Periotris.Net/blob/main/LICENSE >.
 */

using Periotris.Net.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Periotris.Net.ViewModel
{
    public sealed class ColorModeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ColorMode colorMode)
            {
                switch (colorMode)
                {
                    case ColorMode.Default:
                        return Properties.MainWindowResources.ColorModeDefaultCaption;

                    case ColorMode.None:
                        return Properties.MainWindowResources.ColorModeNoneCaption;

                    default:
                        break;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}