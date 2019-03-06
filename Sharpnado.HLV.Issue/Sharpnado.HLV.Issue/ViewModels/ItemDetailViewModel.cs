using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sharpnado.HLV.Issue.Models;
using Xamarin.Forms;

namespace Sharpnado.HLV.Issue.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ObservableCollection<MediaItem> Media { get; set; }
        public bool HasMedia { get; set; }
        public Item Item { get; set; }

        public Command<string> OpenLinkCommand { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Media = new ObservableCollection<MediaItem>(new List<MediaItem>
            {
                new MediaItem(false, "https://www.gstatic.com/webp/gallery/1.jpg"),
                new MediaItem(false, "https://www.gstatic.com/webp/gallery/2.jpg"),
                new MediaItem(true, "https://i.ytimg.com/vi/4XVxKeRj3EM/hqdefault.jpg?sqp=-oaymwEYCNIBEHZIVfKriqkDCwgBFQAAiEIYAXAB&rs=AOn4CLBibRUFdKj9M2KC8IKeuiYGEfIm7w", "https://www.youtube.com/watch?v=4XVxKeRj3EM"),
                new MediaItem(false, "https://www.gstatic.com/webp/gallery/3.jpg"),
            });
            HasMedia = Media.Any();

            Title = item?.Text;
            Item = item;

            OpenLinkCommand = new Command<string>(url =>
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    return;
                }

                Device.OpenUri(new Uri(url));
            });
        }
    }
}
