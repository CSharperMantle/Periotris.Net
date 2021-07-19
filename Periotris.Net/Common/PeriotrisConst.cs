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

namespace Periotris.Net.Common
{
    public static class PeriotrisConst
    {
        public const string DefaultMapJsonFileName = "pack://application:,,,/Assets/DefaultMap.json";
        public const string HistoryFileName = "history.json";
        public const double OriginalGameUpdateIntervalSeconds = 1.5;
        public const string PeriodicTableJsonFileName = "pack://application:,,,/Assets/PeriodicTable.json";
        public const string SettingsFileName = "settings.json";
        public const double TimeDecreaseDeltaSeconds = 0.025;
        public const double TimeDisplayUpdateIntervalSeconds = 0.1;
        public static readonly string PeriotrisGameDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Periotris.Net/";

        /// <summary>
        ///     Current update interval for the game timer.
        /// </summary>
        public static double GameUpdateIntervalSeconds = OriginalGameUpdateIntervalSeconds;
    }
}