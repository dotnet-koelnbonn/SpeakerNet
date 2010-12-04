using System;

namespace SpeakerNet.Data
{
    public interface IDatabaseContext : IDisposable
    {
        SpeakerNetDbContext DbContext { get; }
    }
}