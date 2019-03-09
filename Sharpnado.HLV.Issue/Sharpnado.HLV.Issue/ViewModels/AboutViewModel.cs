using Sharpnado.HLV.Issue.Navigation;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Sharpnado.HLV.Issue.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private INavigationService _navigation => DependencyService.Get<INavigationService>();

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            BackCommand = new Command(async () => await _navigation.Back());
        }

        public ICommand OpenWebCommand { get; }
        public ICommand BackCommand { get; }
    }
}