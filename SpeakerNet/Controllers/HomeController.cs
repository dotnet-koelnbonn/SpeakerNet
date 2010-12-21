using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;

namespace SpeakerNet.Controllers
{
    public class HomeController : SpeakerNetController
    {
        [AdminOnly]
        public ActionResult Index()
        {
            ViewBag.Message = "Willkommen bei ASP.NET";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
