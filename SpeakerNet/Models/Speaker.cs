using System;

namespace SpeakerNet.Models
{
    public class Speaker
    {
        private Speaker() {}

        public static Speaker Create()
        {
            return new Speaker
            {
                Id = Guid.NewGuid()
            };
        }

        public Guid Id { get; private set; }
    }
}