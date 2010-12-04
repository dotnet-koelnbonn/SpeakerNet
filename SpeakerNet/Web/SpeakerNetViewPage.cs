using System;
using System.Web.Mvc;
using SpeakerNet.Properties;
using SpeakerNet.Settings;

namespace SpeakerNet.Web
{
    public abstract class SpeakerNetViewPage<TModel> : WebViewPage<TModel>
    {
        public ISiteSettings SiteSettings
        {
            get { return new SiteSettings(new AppSettings()); }
        }

        public override System.Web.WebPages.HelperResult RenderPage(string path, params object[] data)
        {
            return base.RenderPage(Context.GetLayoutPath(path), data);
        }

        protected string T(string resourceName, params object[] args)
        {
            string format = SpeakertNetStrings.ResourceManager.GetString(resourceName, SpeakertNetStrings.Culture);
            if (format == null) {
                format = "Missing: " + resourceName;
            }
            return string.Format(SpeakertNetStrings.Culture, format, args);
        }
    }
}