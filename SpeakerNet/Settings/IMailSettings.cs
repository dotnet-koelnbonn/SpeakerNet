namespace SpeakerNet.Settings
{
    public interface IMailSettings
    {
        string From { get; }
        string Cc { get; }
    }

    public class MailSettings : IMailSettings
    {
        private readonly IAppSettings settings;

        public MailSettings(IAppSettings settings)
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