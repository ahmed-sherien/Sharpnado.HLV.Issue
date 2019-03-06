using Sharpnado.HLV.Issue.Models;
using Sharpnado.HLV.Issue.Navigation;
using Sharpnado.HLV.Issue.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Sharpnado.HLV.Issue.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private List<HomeMenuItem> _allMenuItems = new List<HomeMenuItem>()
            {
                new HomeMenuItem {Id = PageType.Items, Title = "Login" },
                new HomeMenuItem {Id = PageType.About, Title = "About" },
            };

        private ObservableCollection<HomeMenuItem> _menuItems;

        public ObservableCollection<HomeMenuItem> MenuItems { get => _menuItems; set { SetProperty(ref _menuItems, value); } }

        public Command<HomeMenuItem> NavigateCommand { get; set; }

        private INavigationService _navigation => DependencyService.Get<INavigationService>();

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<HomeMenuItem>(_allMenuItems.Where(i => i.IsEnabled()));
            NavigateCommand = new Command<HomeMenuItem>(async item =>
            {
                await _navigation.NavigateTo(item.Id);
            });
        }
    }
}
