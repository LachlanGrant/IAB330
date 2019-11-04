using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroupR.Models;

using System.Net.Http;
using Newtonsoft.Json;
//using System.Diagnostics;

using Xamarin.Essentials;

namespace GroupR.Services
{
    public class LoginServiceStore 
    {
        public async Task<bool> RegisterAsync(string username, string password)
        {
            var client = new System.Net.Http.HttpClient();

            var jsonData = new StringContent(JsonConvert.SerializeObject(new
            {
                username = username,
                password = password,
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/signup", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJSON);

            //var resp = JsonConvert.DeserializeObject(responseJSON);

            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseJSON);

            if (userResponse.Success == true)
            {
                return true;
            }

            return false;
        }

        public async Task<UserResponse> LoginAsync(string username, string password)
        {
            var client = new System.Net.Http.HttpClient();

            var jsonData = new StringContent(JsonConvert.SerializeObject(new
            {
                username = username,
                password = password,
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://iab330.rbvea.co/api/token", jsonData);
            string responseJSON = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseJSON);

            //var resp = JsonConvert.DeserializeObject(responseJSON);

            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseJSON);

            if (userResponse.Success == true)
            {
                return userResponse;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
