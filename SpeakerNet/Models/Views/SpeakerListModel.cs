using System;
using SpeakerNet.Attributes;
using SpeakerNet.Extensions;
using SpeakerNet.FilterAttributes;

namespace SpeakerNet.Models.Views
{
    public class SpeakerListModel
    {
        public Guid Id { get; set; }
        [Label("Speaker_Name")]
        public string Fullname { get; set; }
    }
}