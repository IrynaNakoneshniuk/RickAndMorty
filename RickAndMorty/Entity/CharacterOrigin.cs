using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.NewFolder
{
    public class CharacterOrigin
    {
        public CharacterOrigin(string name = "", Uri url = null)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; set; }
        public Uri Url { get; set; }
    }
}
