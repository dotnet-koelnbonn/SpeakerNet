using System;
using System.IO;
using System.Web;

namespace SpeakerNet.ViewModels
{
    public class PictureUploadShowModel
    {
        public int Id { get; set; }
        public Guid SpeakerId { get; set; }
        public string SpeakerFullName { get; set; }
        public HttpPostedFile Picture { get; set; }
    }
}