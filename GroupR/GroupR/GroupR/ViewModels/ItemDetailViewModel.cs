using System;

using GroupR.Models;

namespace GroupR.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Review Item { get; set; }
        public ItemDetailViewModel(Review item = null)
        {
            Title = item?.name;
            Item = item;
        }
    }
}
