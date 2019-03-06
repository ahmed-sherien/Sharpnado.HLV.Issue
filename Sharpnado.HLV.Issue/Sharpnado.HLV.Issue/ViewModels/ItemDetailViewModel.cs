using System;

using Sharpnado.HLV.Issue.Models;

namespace Sharpnado.HLV.Issue.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
