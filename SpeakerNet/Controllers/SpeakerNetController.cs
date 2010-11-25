using System.Web.Mvc;
using SpeakerNet.Infrastructure.Mvc;

namespace SpeakerNet.Controllers
{
    public abstract class SpeakerNetController :Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new StructureMapControllerActionInvoker();
        }
    }
}