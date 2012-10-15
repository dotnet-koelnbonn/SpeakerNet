using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class DisplaySessionModel
    {
        [Label("Session_Name")]
        public string Name { get; set; }

        [Label("Session_Abstract")]
        [UIHint("_Wiki")]
        public string Abstract { get; set; }

        [Label("Session_Level")]
        public int Level { get; set; }

        [Label("Session_Duration")]
        [DisplayFormat(DataFormatString = "{0} min")]
        public int Duration { get; set; }

        [Label("Session_Event")]
        public string EventName { get; set; }

        [Label("Session_Speaker")]
        public string SpeakerFullName { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid SpeakerId { get; set; }

        [Label("Session_Selected")]
        public bool Selected { get; set; }

        [ScaffoldColumn(false)]
        public bool ShowSessionSelection { get; set; }
    }
}