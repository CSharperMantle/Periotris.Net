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
using Periotris.Net.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Periotris.Net.View
{
    /// <summary>
    ///     Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();

            if (Resources["ViewModel"] is PeriotrisViewModel viewModel)
            {
                _viewModel = viewModel;
            }
            else
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
        }

        private readonly PeriotrisViewModel _viewModel;

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo(PageType.StartPage);
        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StartGame();
        }

        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.PreviewKeyDown += GamePage_PreviewKeyDown;
        }

        private void GamePage_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = _viewModel.OnKeyDown(e.Key);
        }

        private void GamePage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePlayAreaSize(new Size(e.NewSize.Width, e.NewSize.Height - 160));
        }

        private void GamePage_Unloaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.PreviewKeyDown -= GamePage_PreviewKeyDown;
        }

        private void PlayArea_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlayAreaSize(PlayArea.RenderSize);
        }

        private void UpdatePlayAreaSize(Size newSize)
        {
            double targetWidth;
            double targetHeight;
            if (newSize.Width > newSize.Height)
            {
                targetWidth = newSize.Height * (PeriotrisConst.PlayAreaWidth / (double)PeriotrisConst.PlayAreaHeight);
                targetHeight = newSize.Height;
            }
            else
            {
                targetHeight = newSize.Width * (PeriotrisConst.PlayAreaHeight / (double)PeriotrisConst.PlayAreaWidth);
                targetWidth = newSize.Width;
            }

            PlayArea.Width = targetWidth;
            PlayArea.Height = targetHeight;
            _viewModel.PlayAreaSize = new Size(targetWidth, targetHeight);
        }
    }
}