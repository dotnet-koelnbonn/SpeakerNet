using System;
using System.Configuration;
using System.Globalization;

namespace SpeakerNet.Settings
{
    public class AppSettings : IAppSettings
    {
        public T Get<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
                return default(T);
            return (T) Convert.ChangeType(value, typeof (T), CultureInfo.InvariantCulture);
        }
    }
}