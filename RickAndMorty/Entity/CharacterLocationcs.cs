using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.NewFolder
{
    public class CharacterLocation
    {
        public CharacterLocation(string name = "", Uri url = null)
        {
            Name = name;
            Url = url;
        }
        [JsonProperty ("name")]
        public string Name { get; }
        [JsonProperty ("url")]
        public Uri Url { get; }
    }
}
