using MahApps.Metro.Controls;
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
        private readonly MainWindowViewModel _viewModel;

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

        private void LaunchGitHubRepo(object sender, RoutedEventArgs eventArgs)
        {
            Process.Start("https://github.com/CSharperMantle/Periotris.Net");
        }
    }
}