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
using System;
using System.IO;

namespace Periotris.Net.Customization.Settings
{
    /// <summary>
    ///     Support a way to obtain <see cref="Settings" /> from a persistent
    ///     on-disk JSON file.
    /// </summary>
    public sealed class SettingsManager
    {
        /// <summary>
        ///     Get the instance of <see cref="SettingsManager" />.
        /// </summary>
        public static SettingsManager Instance => instance.Value;

        /// <summary>
        ///     The exposed <see cref="Settings"/> object to which user can write.
        ///     Disk data persistence will be guaranteed by the property.
        /// </summary>
        public Settings Settings
        {
            get => settings;
            set
            {
                settings = value;
                WriteIntoFile();
            }
        }

        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<SettingsManager> instance
            = new(() => new SettingsManager());

        private Settings settings = Settings.Default;

        private SettingsManager()
        {
            ReadFromFile();
            WriteIntoFile();
        }

        private void ReadFromFile()
        {
            using Stream settingsStream = FileIO.OpenStreamByType(PeriotrisConst.SettingsFileName, PathType.Data);
            if (settingsStream.Length <= 0)
            {
                // File is newly created - file does not exist before
                settings = Settings.Default;
            }
            else
            {
                using StreamReader reader = new(settingsStream);
                JsonSerializer serializer = new();
                object readObject = serializer.Deserialize(reader, typeof(Settings));
                settings = readObject != null
                    ? (Settings)readObject
                    : throw new FileNotFoundException(null, PeriotrisConst.SettingsFileName);
            }
        }

        private void WriteIntoFile()
        {
            using Stream settingsStream = FileIO.OpenStreamByType(PeriotrisConst.SettingsFileName, PathType.Data);
            settingsStream.SetLength(0); // Truncate original stream
            using StreamWriter writer = new(settingsStream);
            JsonSerializer serializer = new();
            serializer.Serialize(writer, settings, typeof(Settings));
        }
    }
}