using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDogLover.Models.Profile
{
    public class Profile : BaseViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Favorite Hot Dog")]
        public HotDog.HotDog FavoriteDog { get; set; }

        [Display(Name = "Last Place Ate")]
        public string LastAte { get; set; }

        public List<HotDog.HotDog> HotDogs { get; set; } 

    }
}