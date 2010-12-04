using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Event
    {
        protected Event()
        {
        }

        public static Event Create(string name)
        {
            return new Event {Name = name};
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int Id { get; private set; }
    }
}