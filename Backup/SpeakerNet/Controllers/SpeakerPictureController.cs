using System;
using System.Drawing;
using System.Web.Helpers;
using System.Web.Mvc;
using SpeakerNet.Models;
using SpeakerNet.Services;

namespace SpeakerNet.Controllers
{
    public class SpeakerPictureController : SpeakerNetController
    {
        private readonly ISpeakerPictureService service;

        public SpeakerPictureController(ISpeakerPictureService service)
        {
            this.service = service;
        }

        public ActionResult Show(Guid speakerId, int width, int height, string mode = "")
        {
            SpeakerPicture speakerPicture = service.TryGetPicture(speakerId);
            if (speakerPicture == null)
                return new HttpNotFoundResult();

            var image = new WebImage(speakerPicture.Picture);
            if (width > 0 && height > 0)
            {
                if (mode == "crop")
                    image = CropImage(image, width, height);
                else
                    image = image.Resize(width, height);
            }

            return File(image.GetBytes(), image.ImageFormat);
        }

        private WebImage CropImage(WebImage image, int width, int height)
        {
            var cropper = new Cropping();
            double multi = cropper.GetMultiplicator(new Size(image.Width, image.Height), new Size(width, height));
            
            double fWidth = image.Width*multi;
            double fHeight = image.Height*multi;

            image = image.Resize((int)fWidth, (int)fHeight,preserveAspectRatio:false    );
            int iWidth = image.Width;
            int iHeight = image.Height;
            int top = Math.Max((iHeight - height) / 2, 0);
            int left = Math.Max((iWidth - width) / 2, 0);
            int bottom = Math.Max(iHeight - (height + top), 0);
            int right = Math.Max(iWidth - (width + left), 0);
            return image.Crop(top, left, bottom, right);
        }
    }
}