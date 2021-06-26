using MahApps.Metro.Controls;
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

            NavigationHelper.NavigateTo(PageType.StartPage);
        }

        public void NavigateTo(string relativeUri)
        {
            MainFrame.Navigate(new Uri(relativeUri, UriKind.Relative));
        }

        public void SwitchAboutFlyout()
        {
            AboutFlyout.IsOpen = !AboutFlyout.IsOpen;
        }

        public bool GetAboutFlyoutOpenness()
        {
            return AboutFlyout.IsOpen;
        }

        private void LaunchGitHubRepo(object sender, RoutedEventArgs eventArgs)
        {
            Process.Start("https://github.com/CSharperMantle/CmTetris");
        }
    }
}