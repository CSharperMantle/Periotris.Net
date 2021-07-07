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
using System.Windows.Markup;

namespace Periotris.Net.View
{
    public sealed class MainWindowEnumerateExtension : MarkupExtension
    {
        public MainWindowEnumerateExtension(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            string[] names = Enum.GetNames(Type);
            string[] values = new string[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                values[i] = Properties.MainWindowResources.ResourceManager.GetString(
                    string.Format("{0}{1}Caption", Type.Name, names[i])
                );
            }

            return values;
        }
    }
}