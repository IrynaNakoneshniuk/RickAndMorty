using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RickAndMorty.Net.Api.Models.Domain
{
    public class Location
    {
        public Location(int id = 0, string name = "", string type = "", string dimension = "", IEnumerable<Uri> residents = null,
            Uri url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Dimension = dimension;
            Residents = residents;
            Url = url;
            Created = created;
        }
        [JsonProperty("id ")]
        public int Id { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("type")]
        public string Type { get; }
        [JsonProperty("dimension")]
        public string Dimension { get; }
        [JsonProperty("residents")]
        public IEnumerable<Uri> Residents { get; }
        [JsonProperty("url")]
        public Uri Url { get; }
        [JsonProperty("created")]
        public DateTime? Created { get; }
    }
}
