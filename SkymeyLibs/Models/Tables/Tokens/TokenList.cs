using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkymeyLibs.Models.Tables.Tokens
{
    public class TokenList
    {
        [JsonPropertyName("Symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Price")]
        public string Price { get; set; }

        [JsonPropertyName("tfh")]
        public string tfhc { get; set; }

        [JsonPropertyName("sd")]
        public string sdc { get; set; }
    }
}
