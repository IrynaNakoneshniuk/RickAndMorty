using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RickAndMorty.Net.Api.Models.Dto;
using RickAndMorty.Net.Api.Models.Enums;
using RickAndMorty.Net.Api.Models.Domain;
using System.Security.Policy;

namespace RickAndMorty.NewFolder
{
    public class Character
    {
        public Character()
        {
            this.id = 0;
            this.name = null;
            this.status = 0;
            this.species = null;
            this.type = null;
            this.gender = 0;
            this.location = null;
            this.origin = null;
            this.image = null;
            this.episode = null;
            this.url = null;
            this.created = null;
        }
        public Character(
            int id, string name, CharacterStatus status, string species, string type, CharacterGender gender, CharacterLocation location, CharacterOrigin origin, string image, IEnumerable<string>? episode, 
          string? url, DateTime? created)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.species = species;
            this.type = type;
            this.gender = gender;
            this.location = location;
            this.origin = origin;
            this.image = image;
            this.episode = episode;
            this.url = url;
            this.created = created;
        }

        [JsonProperty("id ")]
        public int id { get; set; }
        public string name { get; set; }
        [JsonProperty("status")]
        public CharacterStatus status { get; set; }
        [JsonProperty("species")]
        public string species { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("gender")]
        public CharacterGender gender { get; set; }
        [JsonProperty("location")]
        public CharacterLocation location { get; set; }
        [JsonProperty("origin")]
        public CharacterOrigin origin { get; set; }
        [JsonProperty("image")]
        public string image { get; set; }
        [JsonProperty("episode")]
        public IEnumerable<string>? episode { get; set; }
        [JsonProperty("url")]
        public string ?url { get; set; }
        [JsonProperty("created_at")]
        public DateTime? created { get; set; }
    }
}
