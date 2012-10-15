using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;

namespace SpeakerNet.Controllers
{
    public class HomeController : SpeakerNetController
    {
        public ActionResult Index()
        {

            ViewBag.Message = "Willkommen im SpeakerNet";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
