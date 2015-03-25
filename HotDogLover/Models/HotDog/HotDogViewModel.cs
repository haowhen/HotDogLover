using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Models.HotDog
{
    public class HotDogViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}