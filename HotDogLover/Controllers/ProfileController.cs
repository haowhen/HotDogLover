using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HotDogLover.Models.Profile;
using HotDogLover.Service;

namespace HotDogLover.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            var service = new ProfileService();
            var profiles = service.GetProfileIndexViewModels();

            return View(profiles);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Detail(Guid id)
        {
            var service = new ProfileService();

            var vm = new ProfileViewModel { Profile = service.GetProfile(id) };

            return View(vm);
        }

        public ActionResult Update(Guid id)
        {
            var service = new ProfileService();

            return View(service.GetProfileUpdateViewModel(id));
        }

        [HttpPost]
        public ActionResult Update(ProfileUpdateViewModel viewModel)
        {
            var service = new ProfileService();

            service.Update(viewModel);

            return RedirectToAction("Detail", new {id = viewModel.Id});
        }
    }
}