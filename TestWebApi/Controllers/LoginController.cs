using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Redirect("https://www.reachindians.com");
        }

        [AllowAnonymous]                        
        public IHttpActionResult Post([FromBody] LoginUserInfo user)
        {
            var userProfile = VerifyToken(user.IdToken);

            return Ok(true);
        }        
        
        public GoogleOAuthProfile VerifyToken(string idToken)
        {
            GoogleOAuthProfile userProfile = null;

            try
            {
                var _httpClient = new HttpClient();

                string googleVerificationUrl = string.Format("{0}?id_token={1}", ConfigurationManager.AppSettings.Get("GoogleTokenVerificationUrl"), idToken);

                var body = new List<KeyValuePair<string, string>>();

                // Request the token
                HttpResponseMessage tokenResponse = _httpClient.PostAsync(googleVerificationUrl, new FormUrlEncodedContent(body)).Result;
                tokenResponse.EnsureSuccessStatusCode();
                string text = tokenResponse.Content.ReadAsStringAsync().Result;

                // Deserializes the token response
                JObject response = JObject.Parse(text);

                userProfile = JsonConvert.DeserializeObject<GoogleOAuthProfile>(text);
            }
            catch (Exception ex)
            {
                                
            }

            return userProfile;
            
        }
      
    }
}
