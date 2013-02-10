using System;
using System.Linq;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Services;

namespace SpeakerNet.Controllers
{
    [AdminOnly]
    public class SessionVotingController : SpeakerNetController
    {
        readonly ISessionVotingService service;

        public SessionVotingController(ISessionVotingService service)
        {
            this.service = service;
        }

        //
        // GET: /SessionVoting/

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 60)]
        public ActionResult Sessions()
        {
            return Json(service.GetListSessionVotingModel());
        }

        public ActionResult Vote(int id, int points)
        {
            return Json(service.Vote(id, points));
        }

    }
}