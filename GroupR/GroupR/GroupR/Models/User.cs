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
        public bool success { get; set; }
    }
}
