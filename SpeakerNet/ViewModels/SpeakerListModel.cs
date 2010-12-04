using System;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class SpeakerListModel
    {
        public Guid Id { get; set; }

        [Label("Speaker_Name")]
        public string Fullname { get; set; }

        [Label("Speaker_Sessions")]
        public int SessionCount { get; set; }
    }
}