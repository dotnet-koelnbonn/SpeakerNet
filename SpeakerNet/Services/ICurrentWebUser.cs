using System;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public interface ICurrentWebUser
    {
        WebUser User { get; }
    }
}