using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RickAndMorty.Entity
{
    public class Page
    {
        public List<Episode> ?Episodes { get; set; }
        public List<Character>? Characters { get; set; }
        public List<BitmapImage>? images { get; set; }   
    }
}
