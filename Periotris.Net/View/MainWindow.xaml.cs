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

using MahApps.Metro.Controls;
using Microsoft.Win32;
using Periotris.Net.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;

namespace Periotris.Net.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Resources["ViewModel"] is MainWindowViewModel viewModel)
            {
                _viewModel = viewModel;
            }
            else
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            NavigationHelper.NavigateTo(PageType.StartPage);
        }

        public void NavigateTo(string relativeUri)
        {
            MainFrame.Navigate(new Uri(relativeUri, UriKind.Relative));
        }

        public void SwitchAboutFlyout()
        {
            _viewModel.SwitchAboutFlyout();
        }

        public void SwitchSettingsFlyout()
        {
            _viewModel.SwitchSettingsFlyout();
        }

        private readonly MainWindowViewModel _viewModel;

        private void LaunchGitHubRepo(object sender, RoutedEventArgs eventArgs)
        {
            _ = OpenUrl("https://github.com/CSharperMantle/Periotris.Net");
        }

        private void MapPathOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "JSON (.json)|*.json";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Multiselect = false;
            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                _viewModel.CustomMapPath = openFileDialog.FileName;
            }
        }

        private Process OpenUrl(string url)
        {
            ProcessStartInfo info = new()
            {
                FileName = url,
                UseShellExecute = true
            };
            return Process.Start(info);
        }
    }
}