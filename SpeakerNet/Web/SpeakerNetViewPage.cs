using System;
using System.Web.Mvc;
using SpeakerNet.Properties;
using SpeakerNet.Settings;

namespace SpeakerNet.Web
{
    public sealed class SpeakerNetViewPage : WebViewPage
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SpeakerNetViewPage<TModel> : WebViewPage<TModel>
    {
        private ISiteSettings siteSettings;

        public ISiteSettings SiteSettings
        {
            get
            {
                if (siteSettings == null)
                    siteSettings = new SiteSettings(new AppSettings());
                return siteSettings;
            }
        }

        public override System.Web.WebPages.HelperResult RenderPage(string path, params object[] data)
        {
            return base.RenderPage(Context.GetLayoutPath(path), data);
        }

        protected string T(string resourceName, params object[] args)
        {
            var format = SpeakerNetStrings.ResourceManager.GetString(resourceName, SpeakerNetStrings.Culture);
            if (format == null) {
                format = "Missing: " + resourceName;
            }
            return string.Format(SpeakerNetStrings.Culture, format, args);
        }
    }
}