using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RickAndMorty.Net.Api.Models.Domain
{
    public class Episode
    {
        public Episode(int id = 0, string name = "", DateTime? airDate = null,
            string episodeCode = "", IEnumerable<Uri> characters = null,
            Uri url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            AirDate = airDate;
            EpisodeCode = episodeCode;
            Characters = characters;
            Url = url;
            Created = created;
        }
        [JsonProperty("id ")]
        public int Id { get; }
        [JsonProperty("name ")]
        public string Name { get; }
        [JsonProperty("air_date ")]
        public DateTime? AirDate { get; }
        [JsonProperty("episodeCode ")]
        public string EpisodeCode { get; }
        public IEnumerable<Uri> Characters { get; }
        [JsonProperty("url")]
        public Uri Url { get; }
        [JsonProperty("created")]
        public DateTime? Created { get; }
    }
}
