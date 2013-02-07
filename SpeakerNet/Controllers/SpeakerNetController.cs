using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using SpeakerNet.Infrastructure.Mvc;
using SpeakerNet.Properties;
using StructureMap;

namespace SpeakerNet.Controllers
{
    public abstract class SpeakerNetController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new DatabaseContextActionInvoker();
        }

        protected string T(string resourceName, params object[] args)
        {
            string format = SpeakerNetStrings.ResourceManager.GetString(resourceName, SpeakerNetStrings.Culture);
            if (format == null)
            {
                format = "Missing: " + resourceName;
            }
            return string.Format(SpeakerNetStrings.Culture, format, args);
        }
    }
}