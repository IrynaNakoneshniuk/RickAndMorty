using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;
using RickAndMorty.NewFolder;
namespace RickAndMorty
{
    public class ObjectsViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private List<Character> _characters;
        private List<Episode> _episodes;
        private List<BitmapImage> _DisplayedImage;
        public string? _DisplayedImagePath;
        public Location? _Location;
        private Page _page;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public List<Character> Characters
        {
            get
            {
                return _characters;
            }
            set
            {
                if (value != null)
                {
                    _characters = value;
                    OnPropertyChanged();
                }
            }
        }
        public Page Page { 
            get{ return _page; }
            set
            {
                if(value != null)
                {
                    _page = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Episode> Episodes
        {
            get
            {
                return _episodes;
            }
            set
            {
                if (value != null)
                {
                    _episodes = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<BitmapImage> DisplayedImage
        {
            get
            {
                _DisplayedImage = new List<BitmapImage>();
                foreach (Character character in _characters)
                {
                    if (!string.IsNullOrEmpty(@character.image))
                    {
                        BitmapImage imageimage = new BitmapImage();
                        imageimage.BeginInit();
                        imageimage.UriSource=new Uri(@character.image);
                        imageimage.EndInit();
                        _DisplayedImage.Add(imageimage);
                    }
                }
                
                return _DisplayedImage;
            }
            set
            {
                _DisplayedImage = value;
                OnPropertyChanged();
            }
        }
        public Location location
        {
            get
            {
                RickAndMortyService rickAndMortyService = new RickAndMortyService();
                _Location = rickAndMortyService.GetLocation(@_characters[0].location.Url.ToString());
                return _Location;
            }
            set
            {
                if (value != null)
                {
                    _Location = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObjectsViewModels()
        {
            RickAndMortyService rickAndMortyService = new RickAndMortyService();
            _characters = rickAndMortyService.GetAllCharacters();
            _episodes = rickAndMortyService.GetAllEpisodes();
        } 
    }
}
