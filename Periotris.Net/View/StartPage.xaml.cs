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

using System.Windows;
using System.Windows.Controls;

namespace Periotris.Net.View
{
    /// <summary>
    ///     Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SwitchAboutFlyout();
            }
        }

        private void NormalGameButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo(PageType.GamePage);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SwitchSettingsFlyout();
            }
        }
    }
}