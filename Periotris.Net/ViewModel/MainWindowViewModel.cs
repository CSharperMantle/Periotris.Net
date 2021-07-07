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
using Periotris.Net.Customization.Settings;
using System.ComponentModel;

namespace Periotris.Net.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool AboutFlyoutOpened { get; set; }

        public AssistanceGridMode AssistanceGridMode
        {
            get => SettingsManager.Instance.Settings.AssistanceGridMode;
            set
            {
                SettingsManager manager = SettingsManager.Instance;
                Settings clone = manager.Settings;
                clone.AssistanceGridMode = value;
                manager.Settings = clone;
            }
        }

        public ColorMode ColorMode
        {
            get => SettingsManager.Instance.Settings.ColorMode;
            set
            {
                SettingsManager manager = SettingsManager.Instance;
                Settings clone = manager.Settings;
                clone.ColorMode = value;
                manager.Settings = clone;
            }
        }

        public bool SettingsFlyoutOpened { get; set; }

        public void SwitchAboutFlyout()
        {
            AboutFlyoutOpened = !AboutFlyoutOpened;
            OnPropertyChanged(nameof(AboutFlyoutOpened));
        }

        public void SwitchSettingsFlyout()
        {
            SettingsFlyoutOpened = !SettingsFlyoutOpened;
            OnPropertyChanged(nameof(SettingsFlyoutOpened));
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}