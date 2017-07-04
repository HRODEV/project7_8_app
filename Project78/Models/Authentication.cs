using Newtonsoft.Json;

namespace Project78.Models
{
    public class Authentication
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserID { get; set; }

        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }

    }
}
