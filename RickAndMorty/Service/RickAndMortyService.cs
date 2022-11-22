using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RickAndMorty.Net.Api.Helpers;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Models.Dto;
using RickAndMorty.Net.Api.Models.Enums;
using RickAndMorty.NewFolder;
using static System.Net.WebRequestMethods;

namespace RickAndMorty.Net.Api.Service
{
   

    internal class RickAndMortyService : BaseService
    {
        public WebClient Client;
        public RickAndMortyService( string baseString= "https://rickandmortyapi.com/"):base(baseString)
        {
            Client = new WebClient();
            Client.BaseAddress = baseString;
        }
        public Character GetCharacter(int id)
        {
            var dto = Get<Character>($"api/character/{id}");
            return (dto);
        }

        public List<Character> GetAllCharacters()
        {
            int count = 0;
            string response = Client.DownloadString("api/character/");
            JObject Search = JObject.Parse(response);
            IList<JToken> results = Search["results"].Children().ToList();
            
            List<Character> characters = new List<Character>();
            foreach (JToken result in results)
            {
               JObject pairs=JObject.Parse(result.ToString());
                JToken jTokens = pairs["location"];
                CharacterLocation character = jTokens.ToObject<CharacterLocation>();    
                
                characters.Add(result.ToObject<Character>());
                characters[count].location = character;
                count++;
            }
            return characters;
        }

        public IEnumerable<Character> GetMultipleCharacters(int[] ids)
        {
            var dto = Get<IEnumerable<Character>>($"api/character/{string.Join(",", ids)}");

            return dto;
        }

        public IEnumerable<Character> FilterCharacters(string name = "",
            CharacterStatus? characterStatus = null,
            string species = "",
            string type = "",
            CharacterGender? gender = null)
        {
            var url = "/api/character/".BuildCharacterFilterUrl(name, characterStatus, species, type, gender);

            var dto = GetPages<Character>(url);

            return dto;
        }

        public List<Location> GetAllLocations()
        {
            string response = Client.DownloadString("api/location/");
            JObject Search = JObject.Parse(response);
            IList<JToken> results = Search["results"].Children().ToList();
            List<Location> location = new List<Location>();
            foreach (JToken result in results)
            {

                location.Add(result.ToObject<Location>());
            }
            return location;
        }

        public IEnumerable<Location> GetMultipleLocations(int[] ids)
        {
            var dto = Get<IEnumerable<Location>>($"api/location/{string.Join(",", ids)}");
            return dto;
        }

        public Location GetLocation(string path)
        {
            var dto = Get<Location>(path);

            return dto;
        }

        public IEnumerable<Location> FilterLocations(string name = "",
            string type = "",
            string dimension = "")
        {
            var url = "/api/location/".BuildLocationFilterUrl(name, type, dimension);
            var dto = GetPages<Location>(url);
            return dto;
        }

        public List<Episode> GetAllEpisodes()
        {
            string response = Client.DownloadString("api/episode/");
            JObject Search = JObject.Parse(response);
            IList<JToken> results = Search["results"].Children().ToList();
            List<Episode> location = new List<Episode>();
            foreach (JToken result in results)
            {
                location.Add(result.ToObject<Episode>());
            }
            return location;
        }
        public Episode GetEpisode(int id)
        {
            var dto = Get<Episode>($"api/episode/{id}");

            return dto;
        }
        public IEnumerable<Episode> GetMultipleEpisodes(int[] ids)
        {
            var dto = Get<IEnumerable<Episode>>($"api/episode/{string.Join(",", ids)}");

            return dto;
        }

        public IEnumerable<Episode> FilterEpisodes(string name = "",
            string episode = "")
        {
            var url = "/api/episode/".BuildEpisodeFilterUrl(name, episode);

            var dto = GetPages<Episode>(url);

            return dto;
        }
    }
}
