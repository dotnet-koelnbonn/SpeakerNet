using System;

namespace SpeakerNet.Settings
{
    public interface ISiteSettings
    {
        string SiteName { get; }
    }

    public class SiteSettings : ISiteSettings
    {
        private readonly IAppSettings settings;

        public SiteSettings(IAppSettings settings)
        {
            this.settings = settings;
        }

        public string SiteName
        {
            get { return settings.Get<string>("Site.Name"); }
        }
    }
}