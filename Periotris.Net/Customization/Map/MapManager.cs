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

using Newtonsoft.Json;
using Periotris.Net.Common;
using Periotris.Net.Customization.Settings;
using System;
using System.IO;

namespace Periotris.Net.Customization.Map
{
    /// <summary>
    ///     Support a way to obtain <see cref="Customization.Map.Map" /> from a persistent
    ///     on-disk JSON file.
    /// </summary>
    public sealed class MapManager
    {
        /// <summary>
        ///     Get the instance of <see cref="MapManager" />.
        /// </summary>
        public static MapManager Instance => instance.Value;

        /// <summary>
        ///     The exposed <see cref="Customization.Map.Map"/> object to which user can write.
        ///     Disk data persistence will be guaranteed by the property.
        /// </summary>
        public Map Map => map;

        public void LoadDefault()
        {
            map = Map.Default;
        }

        /// <summary>
        ///     Load external map json file.
        /// </summary>
        /// <param name="absolutePath">Path to map file.</param>
        /// <exception cref="FileNotFoundException"/>
        public void LoadExternal(string absolutePath)
        {
            using Stream mapStream = FileIO.OpenStreamByType(absolutePath, PathType.External);
            using StreamReader reader = new(mapStream);
            JsonSerializer serializer = new();
            object newObj = serializer.Deserialize(reader, typeof(Map));
            map = newObj != null ? (Map)newObj : throw new FileNotFoundException(null, absolutePath);
        }

        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<MapManager> instance
            = new(() => new MapManager());

        private Map map;

        private MapManager()
        {
            if (SettingsManager.Instance.Settings.UseCustomMap)
            {
                LoadExternal(SettingsManager.Instance.Settings.CustomMapPath);
            }
            else
            {
                map = Map.Default;
            }
        }
    }
}