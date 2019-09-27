using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupR.Models;

using System.Net.Http;
using Newtonsoft.Json;

namespace GroupR.Services
{
    class LoginServiceStore 
    {
        public async Task<bool> RegisterAsync(string username, string password)
        {
            var client = new System.Net.Http.HttpClient();

            var user = new User
            {
                Username = username,
                Password = password
            };

            var jsonData = new StringContent(JsonConvert.SerializeObject(new {
                username=  username,
                password= password
            }
            ), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/signup", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();

            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseJSON);

            if (userResponse.success == true)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var client = new System.Net.Http.HttpClient();

            var user = new User
            {
                Username = username,
                Password = password
            };

            var jsonData = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/signup", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();

            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseJSON);

            if (userResponse.success == true)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }


        }

/*        public async Task<IEnumerable<Review>> SearchItems(String SearchQuery)
        {
            var client = new System.Net.Http.HttpClient();
            var jsonData = new StringContent(JsonConvert.SerializeObject(new
            {
                search = SearchQuery,
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/reviews/search", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();

            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseJSON);

            if (userResponse.success == true)
            {
                return reviewsResponse;
            }
            else
            {
                throw new Exception();
            }
        }*/
    }
}
