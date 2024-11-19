﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SkymeyLibs.Models.User
{
    public class SU_001
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [JsonPropertyName("_id")]
        public ObjectId? _id { get; set; }
        [JsonProperty("FirstName")]
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }
        [JsonProperty("LastName")]
        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }
        [JsonProperty("Email")]
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonProperty("RefreshToken")]
        [JsonPropertyName("RefreshToken")]
        public string? RefreshToken { get; set; }
        [JsonProperty("RefreshTokenExpiryTime")]
        [JsonPropertyName("RefreshTokenExpiryTime")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
