using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Session
    {
        protected Session() {}

        public int Id { get; private set; }

        [Required]
        [StringLength(4000)]
        public string Abstract { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public virtual Speaker Speaker { get; set; }

        [Required]
       
        public virtual Event Event { get; set; }

        public static Session Create(string name, string @abstract, int level, int duration)
        {
            return new Session {Name = name, Abstract = @abstract, Level = level, Duration = duration};
        }

        public bool Selected { get; set; }
    }
}