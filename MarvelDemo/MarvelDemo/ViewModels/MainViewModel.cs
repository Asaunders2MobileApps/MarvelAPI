using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MarvelDemo.Models;

namespace MarvelDemo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<Character> _characters;
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
        }

        public void Init()
        {
            LoadCharacters();
        }

        void LoadCharacters()
        {
            Characters = new ObservableCollection<Character>();
            
            // Hard-coded list of Characters instead of pulling from the API so we can get just the specific Avengers we want to display:
            Characters.Add(new Character
            {
                Id = 1009368,
                Name = "Ezio Is Our Ally",
                IconPath = "ironman_52.png",
                SeriesId = 2029,
                Thumbnail =
                    new Image {Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/c0/527bb7b37ff55/standard_medium", Extension = "jpg"}
            });
            Characters.Add(new Character
            {
                Id = 1009220,
                Name = "Leonardo is our most valuble asset",
                IconPath = "captainamerica_52.png",
                SeriesId = 1996,
                Thumbnail =
                    new Image {Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/50/537ba56d31087/standard_medium", Extension = "jpg"}
            });
            Characters.Add(new Character
            {
                Id = 1009664,
                Name = "The Brotherhood is our family",
                IconPath = "thor_52.png",
                SeriesId = 2083,
                Thumbnail =
                    new Image {Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350/standard_medium", Extension = "jpg"}
            });
            Characters.Add(new Character
            {
                Id = 1009652,
                Name = "Viviere is our ally",
                IconPath = "thor_52.png", // thanos
                SeriesId = 2116,
                Thumbnail =
                    new Image { Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/40/5274137e3e2cd", Extension = "jpg" }
            });
            Characters.Add(new Character
            {
                Id = 1009208,
                Name = "The Brotherhood is our family",
                IconPath = "thor_52.png", //Brood
                SeriesId = 22727,
                Thumbnail =
                    new Image { Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/40/5260321259f91", Extension = "jpg" }
            });
        }
    }
}
