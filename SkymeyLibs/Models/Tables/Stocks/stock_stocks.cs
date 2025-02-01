using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkymeyLibs.Models.Tables.Stocks
{
    public class stock_stocks
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [JsonPropertyName("_id")]
        public ObjectId? _id { get; set; }
        [JsonPropertyName("Currency")]
        public string Currency { get; set; }
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        [JsonPropertyName("Figi")]
        public string Figi { get; set; }
        [JsonPropertyName("Isin")]
        public string Isin { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Exchange")]
        public string? Exchange { get; set; }
        [JsonPropertyName("Sector")]
        public string Sector { get; set; }
        [JsonPropertyName("Ticker")]
        public string Ticker { get; set; }
        [JsonPropertyName("Dividends")]
        public bool Dividends { get; set; }
        [JsonPropertyName("Updated")]
        public DateTime Updated { get; set; }
    }
}
