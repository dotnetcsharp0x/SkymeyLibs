using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SkymeyLibs.Models.Tables.Posts
{
    public class API_POST_PARAMS
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [JsonPropertyName("_id")]
        public ObjectId? _id { get; set; }
        public ObjectId? POST_ID { get; set; }
        public string Title { get; set; }
        public string Param_ID { get; set; }
        public string Description { get; set; }
    }
}
