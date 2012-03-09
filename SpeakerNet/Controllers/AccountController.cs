using System;
using System.Web.Mvc;
using Microsoft.IdentityModel.Web;

namespace SpeakerNet.Controllers
{
    public class AccountController : SpeakerNetController
    {
        [Authorize]
        public ActionResult LogOn()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            var authenticationModule = FederatedAuthentication.SessionAuthenticationModule;
            if (authenticationModule != null)
                authenticationModule.DeleteSessionTokenCookie();
            return RedirectToAction("Index", "Home");
        }

    }
}
