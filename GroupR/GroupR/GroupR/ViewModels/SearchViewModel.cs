using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GroupR.Models;
using GroupR.Views;

namespace GroupR.ViewModels
{
    public class SearchViewModel: BaseViewModel
    {
        public ObservableCollection<Review> Reviews { get; set; }

        public String SearchQuery { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SearchViewModel()
        {
            Title = "Search Reviews";
            Reviews = new ObservableCollection<Review>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Reviews.Clear();
                var items = await DataStore.SearchItems(SearchQuery);
                foreach (var item in items)
                {
                    Reviews.Add(item);
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
