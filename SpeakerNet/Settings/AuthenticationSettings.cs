namespace SpeakerNet.Settings
{
    public class AuthenticationSettings : IAuthenticationSettings {
        private readonly IAppSettings settings;

        public AuthenticationSettings(IAppSettings settings)
        {
            this.settings = settings;
        }

        public string Username
        {
            get { return settings.Get<string>("Auth.Username"); }
        }

        public string Password
        {
            get { return settings.Get<string>("Auth.Password"); }
        }
    }
}