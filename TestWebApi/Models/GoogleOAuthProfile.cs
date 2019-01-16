using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    public class GoogleOAuthProfile
    {
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        [JsonProperty("family_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("name")]
        public string DisplayName { get; set; }
    }
}