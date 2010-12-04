using System;
using System.Web.Mvc;
using SpeakerNet.Services;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Controllers
{
    public class SpeakerSessionController : SpeakerNetController
    {
        private readonly ISpeakerSessionService service;

        public SpeakerSessionController(ISpeakerSessionService service)
        {
            this.service = service;
        }

        public ActionResult List(Guid speakerId)
        {
            return View(service.GetSpeakerSessionList(speakerId));
        }

        public ActionResult Details(Guid speakerId, int id)
        {
            return View(service.GetDisplaySessionModel(speakerId, id));
        }

        public ActionResult CreateSession(Guid speakerId)
        {
            var model = new CreateSessionModel {SpeakerId = speakerId};
            SetSelectLists(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSession(Guid speakerId, CreateSessionModel model)
        {
            if (ModelState.IsValid) {
                service.CreateSession(speakerId, model);
                return RedirectToAction("List", new {speakerId});
            }
            SetSelectLists(model);
            return View(model);
        }

        public ActionResult EditSession(Guid speakerId, int id)
        {
            var model = service.GetEditSessionModel(speakerId, id);
            SetSelectLists(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSession(Guid speakerId, int id, EditSessionModel model)
        {
            if (ModelState.IsValid) {
                service.UpdateSession(speakerId, id, model);
                return RedirectToAction("Details", new {speakerId, id});
            }
            SetSelectLists(model);
            return View(model);
        }

        private void SetSelectLists(ISessionSelectLists model)
        {
            model.LevelSelectList =
                new SelectList(new[] {
                    new SelectListItem {Value = "100", Text = T("Session_Level100")},
                    new SelectListItem {Value = "200", Text = T("Session_Level200")},
                    new SelectListItem {Value = "300", Text = T("Session_Level300")},
                    new SelectListItem {Value = "400", Text = T("Session_Level400")}
                }, "Value", "Text");
            model.DurationSelectList = new SelectList(new[] {
                new SelectListItem {Value = "30", Text = T("Session_1_Minutes", 30)},
                new SelectListItem {Value = "45", Text = T("Session_1_Minutes", 45)},
                new SelectListItem {Value = "60", Text = T("Session_1_Minutes", 60)}
            }, "Value", "Text");
            model.EventSelectList = new SelectList(service.GetEventList(), "Id", "Name");
        }
    }
}