using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Sharpnado.HLV.Issue.Models;
using Sharpnado.HLV.Issue.Views;
using Sharpnado.HLV.Issue.Navigation;

namespace Sharpnado.HLV.Issue.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private INavigationService _navigation => DependencyService.Get<INavigationService>();

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ShowItemDetailsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ShowItemDetailsCommand = new Command(async (item) =>
            {
                await _navigation.NavigateTo(PageType.Item, new ItemDetailViewModel((Item)item));
            });

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}