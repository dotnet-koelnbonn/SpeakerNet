using System;

namespace SpeakerNet.Settings
{
    public interface IAppSettings
    {
        T Get<T>(string name);
    }
}