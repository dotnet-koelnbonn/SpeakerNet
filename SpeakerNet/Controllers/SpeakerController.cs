using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
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

        public ActionResult Edit(Guid id)
        {
            return View(speakerService.GetSpeaker(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditCommand(Guid id)
        {
            var speaker = speakerService.GetSpeaker(id);
            if (TryUpdateModel(speaker))
            {
                speakerService.Update();
                return RedirectToAction("Details", new {speaker.Id});
            }
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
            return View(speakerService.GetSpeaker(id));
        }
    }
}