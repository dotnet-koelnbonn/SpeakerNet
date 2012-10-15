using Aperea.Settings;

namespace SpeakerNet.Settings
{
    public class AuthenticationSettings : IAuthenticationSettings {
        private readonly IApplicationSettings settings;

        public AuthenticationSettings(IApplicationSettings settings)
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