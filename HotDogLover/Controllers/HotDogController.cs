using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HotDogLover.Models.HotDog;
using HotDogLover.Models.Profile;
using HotDogLover.Service;

namespace HotDogLover.Controllers
{
    public class HotDogController : Controller
    {
        public ActionResult Create(Guid profileId)
        {
            var service = new ProfileService();

            return View(service.GetHotDogCreateViewModel(profileId));
        }

        [HttpPost]
        public ActionResult Create(HotDogCreateViewModel viewModel)
        {
            var service = new ProfileService();

            service.CreateHotDogViewModel(viewModel);

            return RedirectToAction("Detail", "Profile", new {id = viewModel.ProfileId});
        }
    }
}