using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotDogLover.Models.Profile
{
    public class ProfileIndexViewModel : BaseViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Favorite Hot Dog")]
        public string FavoriteDog { get; set; }

        [Display(Name = "Last Place Ate")]
        public string LastAte { get; set; }
    }
}