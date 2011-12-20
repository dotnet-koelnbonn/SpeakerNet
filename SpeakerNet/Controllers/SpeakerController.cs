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
        readonly ISpeakerService _speakerService;
        readonly ISendMailService mailService;

        public SpeakerController(ISpeakerService speakerService, ISendMailService mailService)
        {
            this._speakerService = speakerService;
            this.mailService = mailService;
        }

        public ActionResult Help(Guid id)
        {
            return View(new SpeakerHelpModel {Id = id});
        }

        public ActionResult Details(Guid id)
        {
            return View(_speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }

        public ActionResult Edit(Guid id)
        {
            return View(_speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditCommand(Guid id, SpeakerEditModel model)
        {
            if (ModelState.IsValid) {
                _speakerService.UpdateSpeaker(id, model);
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
        public ActionResult SendMail(Guid id)
        {
            return View(_speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }

        [AdminOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail(Guid id, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(subject))
                ModelState.AddModelError("subject", "Betreff muss vorhanden sein");
            if (string.IsNullOrWhiteSpace(body))
                ModelState.AddModelError("body", "Text muss vorhanden sein");

            var speaker = _speakerService.GetSpeaker(id);

            if (string.IsNullOrWhiteSpace(speaker.Contact.EMail)) {
                ModelState.AddModelError("", "Für den Sprecher ist keine Mail hinterlegt");
            }

            if (ModelState.IsValid) {
                try {
                    mailService.SendMail(speaker.Contact.EMail, subject, body);
                    return RedirectToAction("Details", new {id});
                } catch (Exception e) {
                    ModelState.AddModelError("", string.Format("{0}: {1} ", e.GetType().Name, e.Message));
                }
            }
            return View(_speakerService.GetSpeaker(id).MapFrom<Speaker, SpeakerEditModel>());
        }


        [AdminOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSpeakerModel model)
        {
            if (ModelState.IsValid) {
                if (_speakerService.CreateSpeaker(model))
                    return RedirectToAction("List");
            }
            return View();
        }

        [AdminOnly]
        public ActionResult List()
        {
            return View(_speakerService.GetSpeakerList());
        }
    }
}