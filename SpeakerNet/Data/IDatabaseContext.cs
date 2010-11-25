using System;

namespace SpeakerNet.Data
{
    public interface IDatabaseContext
    {
        SpeakerNetContext DbContext { get; }
    }
}