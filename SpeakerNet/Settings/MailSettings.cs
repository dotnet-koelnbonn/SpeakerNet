using System;
using Aperea.Settings;

namespace SpeakerNet.Settings
{
    public class MailSettings : IMailSettings
    {
        private readonly IApplicationSettings settings;

        public MailSettings(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public string From
        {
            get { return settings.Get<string>("Mail.From"); }
        }

        public string Cc
        {
            get { return settings.Get<string>("Mail.Cc"); }
        }
    }
}