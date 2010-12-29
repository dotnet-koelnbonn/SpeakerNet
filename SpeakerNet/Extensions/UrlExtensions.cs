using System.Web;
using System.Web.Mvc;

namespace SpeakerNet.Extensions
{
    public static class UrlExtensions
    {
        public static string Script(this UrlHelper urlHelper, string scriptName)
        {
            var scriptPath = "~/Scripts/" + scriptName;
            if (urlHelper.RequestContext.HttpContext.IsDebuggingEnabled) {
                scriptPath = scriptPath.Replace(".min.js", ".js");
            }
            return urlHelper.Content(scriptPath);
        }
    }
}