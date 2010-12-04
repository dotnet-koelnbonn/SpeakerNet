using System;
using System.Web.Mvc;
using SpeakerNet.Extensions;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Models;
using SpeakerNet.Services;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Controllers
{
    public class SpeakerController : SpeakerNetController
    {
        private readonly ISpeakerService speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        public ActionResult Help(Guid id)
        {
            return View(new SpeakerHelpModel {Id = id});
        }

        public ActionResult Details(Guid id)
        {
            return View(speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }

        public ActionResult Edit(Guid id)
        {
            return View(speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditCommand(Guid id, SpeakerEditModel model)
        {
            if (ModelState.IsValid) {
                speakerService.UpdateSpeaker(id, model);
                return RedirectToAction("Details", new {id});
            }
            return View(model);
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
            if (ModelState.IsValid) {
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
    }
}