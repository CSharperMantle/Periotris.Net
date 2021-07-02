using System.ComponentModel;

namespace Periotris.Net.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public bool AboutFlyoutOpened { get; set; }

        public bool SettingsFlyoutOpened { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
