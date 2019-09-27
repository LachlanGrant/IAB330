using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GroupR.Models
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }

    public class UserResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("userToken")]
        public string userToken { get; set; }
    }
}
