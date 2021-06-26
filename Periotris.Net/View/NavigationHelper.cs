using System.Windows;

namespace Periotris.Net.View
{
    internal static class NavigationHelper
    {
        public static void NavigateTo(PageType page)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigateTo(page.GetPath());
            }
        }
    }
}