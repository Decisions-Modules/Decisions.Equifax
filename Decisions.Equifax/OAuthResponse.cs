using Newtonsoft.Json;

namespace Decisions.Equifax
{
    /*
     * Data Access Object class for a JSON Oauth2 Response.
     */
    public class OAuthResponse
    {
       [JsonProperty("access_token")]
       public string AccessToken { get; set; }

       [JsonProperty("token_type")]
       public string TokenType { get; set; }

       [JsonProperty("expires_in")]
       public int ExpiresIn { get; set; }

       [JsonProperty("scope")]
       public string Scope { get; set; }
    }
}