using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkymeyLibs.Models.Tables.Posts
{
    public class POST_VIEW_MODEL
    {

        [JsonPropertyName("API_POST")]
        public API_POST API_POST { get; set; }
        [JsonPropertyName("API_POST_CODE_SAMPLES")]
        public List<API_POST_CODE_SAMPLES> API_POST_CODE_SAMPLES { get; set; } = new List<API_POST_CODE_SAMPLES>();
        [JsonPropertyName("API_POST_PARAMS")]
        public List<API_POST_PARAMS> API_POST_PARAMS { get; set; } = new List<API_POST_PARAMS>();
        [JsonPropertyName("API_POST_RESPONSES")]
        public List<API_POST_RESPONSES> API_POST_RESPONSES { get; set; } = new List<API_POST_RESPONSES>();
        [JsonPropertyName("API_POST_TAGS")]
        public List<API_POST_TAGS> API_POST_TAGS { get; set; } = new List<API_POST_TAGS>();
    }
}
