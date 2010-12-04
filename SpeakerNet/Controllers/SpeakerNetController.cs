using System.Web.Mvc;
using SpeakerNet.Data;
using SpeakerNet.Infrastructure.Mvc;
using SpeakerNet.Properties;

namespace SpeakerNet.Controllers
{
    public abstract class SpeakerNetController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            var databaseContext = (IDatabaseContext) DependencyResolver.Current.GetService(typeof (IDatabaseContext));
            return new DatabaseContextActionInvoker(databaseContext,
                                                    new StructureMapControllerActionInvoker());
        }

        protected string T(string resourceName, params object[] args)
        {
            string format = SpeakertNetStrings.ResourceManager.GetString(resourceName, SpeakertNetStrings.Culture);
            if (format == null)
            {
                format = "Missing: " + resourceName;
            }
            return string.Format(SpeakertNetStrings.Culture, format, args);
        }
    }
}