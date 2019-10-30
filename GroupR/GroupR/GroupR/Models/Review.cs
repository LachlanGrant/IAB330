using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GroupR.Models
{
    public class Review
    {
        public String name { get; set; }
        public int friendliness { get; set; }
        public int workEthic { get; set; }
        public int workQuality { get; set; }
        public String studentNumber { get; set; }
        public String subject { get; set; }
        public ReviewUser user { get; set; }
    }

    public class ReviewUser
    {
        public String username { get; set; }

        [JsonProperty("_id")]
        public String id { get; set; }
    }

    public class ReviewResponse
    {
        public bool success { get; set; }
        public List<Review> reviews { get; set; }
    }
}
