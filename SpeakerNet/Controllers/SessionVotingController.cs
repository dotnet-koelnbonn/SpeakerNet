using System;
using System.Linq;
using System.Web.Mvc;
using SpeakerNet.Services;

namespace SpeakerNet.Controllers
{
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
            return View(service.GetListSessionVotingModel());
        }
    }
}