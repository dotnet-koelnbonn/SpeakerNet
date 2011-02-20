using System;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class SessionListModel
    {
        public int Id { get; set; }
        public Guid SpeakerId { get; set; }

        [Label("Session_Name")]
        public string Name { get; set; }

        [Label("Session_Level")]
        public int Level { get; set; }

        [Label("Session_Duration")]
        public int Duration { get; set; }

        [Label("Session_Speaker")]
        public string SpeakerFullName { get; set; }

        [Label("Session_Selected")]
        public bool Selected { get; set; }
    }
}