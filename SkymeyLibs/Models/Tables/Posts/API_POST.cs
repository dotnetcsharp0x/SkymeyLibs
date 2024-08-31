using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkymeyLibs.Models.Tables.Posts
{
    public class API_POST
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [JsonPropertyName("_id")]
        public ObjectId? _id { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Content")]
        public string Content { get; set; }
        [JsonPropertyName("Type")]
        public string Type { get; set; } = "GET";
        [JsonPropertyName("How_To_Send")]
        public string How_To_Send { get; set; }
        [JsonPropertyName("API_URL")]
        public string API_URL { get; set; }
        [JsonPropertyName("DateCreate")]
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("DateUpdate")]
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
