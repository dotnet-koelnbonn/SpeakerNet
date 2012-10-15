using System;
using System.Web;
using System.Web.Mvc;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface IPictureUploadService
    {
        PictureUploadShowModel TryGetShowModel(Guid speakerId);
        PictureUploadUploadModel GetUploadModel(Guid speakerId);
        bool SavePicture(Guid speakerId, HttpPostedFileBase picture);
    }
}