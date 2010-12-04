using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Services;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Controllers
{
    [AdminOnly]
    public class EventController : SpeakerNetController
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View(service.GetEventList());
        }

        public ActionResult Create()
        {
            return View(new CreateEventModel());
        }

        public ActionResult Details(int id)
        {
            return View(service.GetDetailsEventModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventModel model)
        {
            if (ModelState.IsValid){
                service.CreateEvent(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View(service.GetEditEventModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditEventModel model)
        {
            if (ModelState.IsValid){
                service.UpdateEvent(id, model);
                return RedirectToAction("Index");
            }
            return View(service.GetEditEventModel(id));
        }
    }
}