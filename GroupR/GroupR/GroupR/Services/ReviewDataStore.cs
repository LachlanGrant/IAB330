﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupR.Models;

using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace GroupR.Services
{
    public class ReviewDataStore : IDataStore<Review>
    {
        public async Task<bool> AddItemAsync(Review item)
        {
            var client = new System.Net.Http.HttpClient();

            StringContent jsonData = new StringContent(ReviewToJSON(item, Preferences.Get("username", "")), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/reviews/create", jsonData);

            return true;
        }

        public static String ReviewToJSON(Review item, String uname)
        {
            return JsonConvert.SerializeObject(new
            {
                name = item.name,
                workEthic = item.workEthic,
                workQuality = item.workQuality,
                friendliness = item.friendliness,
                studentNumber = item.studentNumber,
                subject = item.subject,
                username = uname,
            });
        }

        public async Task<IEnumerable<Review>> GetItemsAsync(bool forceRefresh = false)
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync("https://iab330.rbvea.co/api/reviews");
            string responseJSON = await response.Content.ReadAsStringAsync();

            ReviewResponse reviewsResponse = JSONtoReviews(responseJSON);
            
            if (reviewsResponse.success == true)
            {
                return reviewsResponse.reviews;
            } else
            {
                throw new Exception();
            }
        }

        public static ReviewResponse JSONtoReviews(String json)
        {
            Console.WriteLine(json);
            return JsonConvert.DeserializeObject<ReviewResponse>(json);
        }

        public async Task<IEnumerable<Review>> SearchItems(String SearchQuery)
        {
            var client = new System.Net.Http.HttpClient();
            var jsonData = new StringContent(JsonConvert.SerializeObject(new
            {
                search = SearchQuery,
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/reviews/search", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();

            ReviewResponse reviewsResponse = JsonConvert.DeserializeObject<ReviewResponse>(responseJSON);

            if (reviewsResponse.success == true)
            {
                return reviewsResponse.reviews;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
