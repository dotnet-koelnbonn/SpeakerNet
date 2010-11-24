using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Models;

namespace SpeakerNet.Controllers
{
    public class SpeakerController : Controller {

        public ActionResult Edit(Speaker speaker)
        {
            return View(speaker);
        }

        [AdminOnly]
        public ActionResult Create()
        {
            return View(Speaker.Create());
        }
    }
}