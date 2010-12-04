using System;
using System.Collections.Generic;

namespace SpeakerNet.ViewModels
{
    public class SpeakerSessionListModel
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IEnumerable<SpeakerSessionIndexModel> Sessions { get; set; }
    }
}