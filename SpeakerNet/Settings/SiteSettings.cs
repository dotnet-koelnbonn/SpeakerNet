using Aperea.Settings;

namespace SpeakerNet.Settings
{
    public class SiteSettings : ISiteSettings
    {
        private readonly IApplicationSettings settings;

        public SiteSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public SiteSettings():this(new ApplicationSettings())
        {
        }

        public string SiteName
        {
            get { return settings.Get<string>("Site.Name"); }
        }
    }
}