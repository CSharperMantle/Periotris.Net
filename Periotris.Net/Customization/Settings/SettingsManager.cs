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
        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<SettingsManager> instance
            = new(() => new SettingsManager());

        /// <summary>
        ///     Get the instance of <see cref="SettingsManager" />.
        /// </summary>
        public static SettingsManager Instance => instance.Value;

        private Settings settings = Settings.Default;

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

        private SettingsManager()
        {
            ReadFromFile();
            WriteIntoFile();
        }

        private void ReadFromFile()
        {
            using FileStream settingsStream = FileIO.OpenDataFile(PeriotrisConst.SettingsFileName);
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
                if (readObject != null)
                {
                    settings = (Settings)readObject;
                }
                else
                {
                    throw new FileNotFoundException(null, PeriotrisConst.SettingsFileName);
                }
            }
        }

        private void WriteIntoFile()
        {
            using FileStream settingsStream = FileIO.OpenDataFile(PeriotrisConst.SettingsFileName);
            using StreamWriter writer = new(settingsStream);
            JsonSerializer serializer = new();
            serializer.Serialize(writer, settings, typeof(Settings));
        }
    }
}
