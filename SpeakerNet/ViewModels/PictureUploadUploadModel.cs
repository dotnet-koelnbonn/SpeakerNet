using System;
using System.IO;
using System.Web;

namespace SpeakerNet.ViewModels
{
    public class PictureUploadUploadModel
    {
        public Guid SpeakerId { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public string SpeakerName { get; set; }
    }
}