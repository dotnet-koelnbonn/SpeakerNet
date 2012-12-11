using System;

namespace SpeakerNet.Services
{
    public interface IFormatter
    {
        string Format(string format, object source);
    }
}