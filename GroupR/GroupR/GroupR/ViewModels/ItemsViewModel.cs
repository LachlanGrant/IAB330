using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GroupR.Models;
using GroupR.Views;

namespace GroupR.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Review> Reviews { get; set; }
        public Command LoadItemsCommand { get; set; }

        public String SearchQuery { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse Reviews";
            Reviews = new ObservableCollection<Review>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Review>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Review;
                Reviews.Add(newItem);
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
                Reviews.Clear();
                if (SearchQuery == null || SearchQuery == "" || SearchQuery == "Search")
                {
                    var items = await DataStore.GetItemsAsync(true);
                    foreach (var item in items)
                    {
                        Reviews.Add(item);
                    }
                } else
                {
                    var items = await DataStore.SearchItems(SearchQuery);
                    foreach (var item in items)
                    {
                        Reviews.Add(item);
                    }
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