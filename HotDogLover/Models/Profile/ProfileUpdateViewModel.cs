using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotDogLover.Models.Profile
{
    public class ProfileUpdateViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        [Display(Name = "Favorite Hot Dog")]
        public HotDog.HotDog FavoriteDog { get; set; }

        [Required]
        [Display(Name = "Last Place Ate")]
        public string LastAte { get; set; }
    }
}