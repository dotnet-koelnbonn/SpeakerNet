using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class CreateSessionModel : ISessionSelectLists
    {
        public CreateSessionModel()
        {
            Duration = 60;
        }
        [Required]
        [StringLength(128)]
        [Label("Session_Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(4000)]
        [Label("Session_Abstract")]
        [DataType(DataType.MultilineText)]
        [UIHint("_Wiki")]
        public string Abstract { get; set; }

        [Required]
        [Label("Session_Level")]
        public int Level { get; set; }

        [Required]
        [Label("Session_Duration")]
        public int Duration { get; set; }

        [Required]
        [Label("Session_Event")]
        public int EventId { get; set; }

        [ScaffoldColumn(false)]
        public Guid SpeakerId { get; set; }

        public SelectList EventSelectList { get; set; }
        public SelectList LevelSelectList { get; set; }
        public SelectList DurationSelectList { get; set; }
    }
}