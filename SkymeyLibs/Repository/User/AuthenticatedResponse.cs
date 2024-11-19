using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkymeyLibs.Repository.User
{
    public class AuthenticatedResponse
    {
        [JsonProperty("AccessToken")]
        [JsonPropertyName("AccessToken")]
        public string? AccessToken { get; set; }
        [JsonProperty("RefreshToken")]
        [JsonPropertyName("RefreshToken")]
        public string? RefreshToken { get; set; }
        [JsonProperty("Status")]
        [JsonPropertyName("Status")]
        public int? Status { get; set; }
    }
}
