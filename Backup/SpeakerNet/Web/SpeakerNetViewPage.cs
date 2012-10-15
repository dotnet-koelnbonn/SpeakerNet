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
        ISiteSettings siteSettings;

        protected ISiteSettings SiteSettings
        {
            get
            {
                if (siteSettings == null)
                    siteSettings = new SiteSettings();
                return siteSettings;
            }
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