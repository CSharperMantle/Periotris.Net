using System;

namespace Periotris.Net.View
{
    internal enum PageType
    {
        StartPage,
        GamePage
    }

    internal static class PageTypeExtenstion
    {
        public static string GetPath(this PageType pageType)
        {
            return pageType switch
            {
                PageType.StartPage => "View/StartPage.xaml",
                PageType.GamePage => "View/GamePage.xaml",
                _ => throw new ArgumentOutOfRangeException(nameof(pageType), pageType, null),
            };
        }
    }
}