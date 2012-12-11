using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Services;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Controllers
{
    public class PictureUploadController : SpeakerNetController
    {
        private readonly IPictureUploadService _service;

        public PictureUploadController(IPictureUploadService service)
        {
            _service = service;
        }

        public ActionResult Show(Guid speakerId)
        {
            var model = _service.TryGetShowModel(speakerId);
            if (model == null)
                return RedirectToAction("Upload",new {speakerId});
            return View(model);
        }

        public ActionResult Upload(Guid speakerId)
        {
            return View(_service.GetUploadModel(speakerId));
        }

        [HttpPost]
        public ActionResult Upload(Guid speakerId,PictureUploadUploadModel model)
        {
            if (model.Picture!=null) {
                if (_service.SavePicture(speakerId, model.Picture)) {
                    return RedirectToAction("Show", new { speakerId });
                }
            }
            return Upload(speakerId);
        }
    }
}