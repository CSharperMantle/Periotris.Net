﻿using System;

namespace Periotris.Net.Common
{
    public static class PeriotrisConst
    {
        public const int PlayAreaWidth = 18;

        public const int PlayAreaHeight = 11;

        public const double OriginalGameUpdateIntervalSeconds = 1.5;

        public const double TimeDisplayUpdateIntervalSeconds = 0.1;

        public const double TimeDecreaseDeltaSeconds = 0.025;

        public const string PeriodicTableJsonFileName = "pack://application:,,,/Assets/PeriodicTable.json";

        /// <summary>
        ///     Current update interval for the game timer.
        /// </summary>
        public static double GameUpdateIntervalSeconds = OriginalGameUpdateIntervalSeconds;

        public const string HistoryFileName = "history.json";

        public const string SettingsFileName = "settings.json";

        public static readonly string PeriotrisGameDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Periotris.Net/";
    }
}