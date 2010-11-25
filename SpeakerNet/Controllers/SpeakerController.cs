using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Models;
using SpeakerNet.Models.Views;
using SpeakerNet.Services;

namespace SpeakerNet.Controllers
{
    public class SpeakerController : SpeakerNetController
    {
        private readonly ISpeakerService speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        public ActionResult Edit(Speaker speaker)
        {
            return View(speaker);
        }

        [AdminOnly]
        public ActionResult Create()
        {
            return View(new CreateSpeakerModel());
        }

        [AdminOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSpeakerModel model)
        {
            if (ModelState.IsValid){
                if (speakerService.CreateSpeaker(model))
                    return RedirectToAction("List");
            }
            return View();
        }

        [AdminOnly]
        public ActionResult List()
        {
            return View(speakerService.GetSpeakerList());
        }

        [AdminOnly]
        public ActionResult Details(Guid id)
        {
            if (ModelState.IsValid)
                return View(speakerService.GetSpeaker(id));
            return RedirectToAction("List");
        }
    }
}