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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Periotris.Net.ViewModel
{
    /// <summary>
    ///     Convert a enum to localized resource string in <see cref="Properties.MainWindowResources"/>.
    /// </summary>
    public sealed class MainWindowEnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            return Properties.MainWindowResources.ResourceManager.GetString(
                string.Format("{0}{1}Caption", value.GetType().Name, value.ToString())
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Properties.MainWindowResources.ResourceManager.GetString(
                    string.Format("{0}{1}Caption", targetType.Name, enumValue.ToString())
                ))
                {
                    return enumValue;
                }
            }

            throw new ArgumentException(null, nameof(value));
        }
    }
}