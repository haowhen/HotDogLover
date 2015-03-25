using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotDogLover.Models.HotDog;

namespace HotDogLover.Models.Profile
{
    public class ProfileCreateViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Rating { get; set; }

        public List<HotDogCreateViewModel> HotDogs { get; set; }
    }
}