using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using GroupR.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace GroupR.Services
{
    public class ReviewDataStore :  IDataStore<Review>
    {
        IEnumerable<Review> reviews;
        HttpClient client;

        public ReviewDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://iab330.rbvea.co/api");

            reviews = new List<Review>();
        }

        public Task<bool> AddItemAsync(Review item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Review>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"/reviews");
                reviews = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Review>>(json));
            }

            return reviews;
        }
    }
}
