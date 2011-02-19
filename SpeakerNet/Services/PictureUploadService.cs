using System;
using System.Linq;
using System.Web;
using SpeakerNet.Data;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class PictureUploadService : IPictureUploadService
    {
        private readonly IRepository<SpeakerPicture> _repository;
        private readonly IRepository<Speaker> _speakerRepository;

        public PictureUploadService(IRepository<SpeakerPicture> repository, IRepository<Speaker> speakerRepository)
        {
            _repository = repository;
            _speakerRepository = speakerRepository;
        }

        public PictureUploadShowModel TryGetShowModel(Guid speakerId)
        {
            var query = from s in _repository.Entities
                        where s.Speaker.Id == speakerId && s.CurrentPicture
                        select new PictureUploadShowModel {
                            Id = s.Id,
                            SpeakerId = s.Speaker.Id,
                            SpeakerFullName = s.Speaker.FirstName + " " + s.Speaker.LastName
                        };
            return query.SingleOrDefault();
        }

        public PictureUploadUploadModel GetUploadModel(Guid speakerId)
        {
            var query = from s in _speakerRepository.Entities
                        where s.Id == speakerId
                        select new PictureUploadUploadModel {
                            SpeakerId = s.Id,
                            SpeakerName = s.FirstName + " " + s.LastName
                        };
            return query.Single();
        }

        public bool SavePicture(Guid speakerId, HttpPostedFileBase picture)
        {
            var speaker = _speakerRepository.Entities.Single(s => s.Id == speakerId);
            ClearCurrentPicturesFromSpeaker(speaker);
            AddPictureToRepository(speaker, picture);
            _repository.SaveChanges();
            return true;
        }

        private void AddPictureToRepository(Speaker speaker, HttpPostedFileBase picture)
        {
            _repository.Add(new SpeakerPicture {
                CurrentPicture = true,
                Speaker = speaker,
                Picture = ReadBytes(picture),
                ContentType = picture.ContentType,
                FileName=picture.FileName
            });
        }

        private byte[] ReadBytes(HttpPostedFileBase picture)
        {
            var bytes = new byte[picture.ContentLength];
            picture.InputStream.Read(bytes, 0, picture.ContentLength);
            picture.InputStream.Dispose();
            return bytes;
        }

        private void ClearCurrentPicturesFromSpeaker(Speaker speaker)
        {
            var query = _repository.Entities.Where(sp => sp.Speaker.Id == speaker.Id);
            foreach (var speakerPicture in query) {
                speakerPicture.CurrentPicture = false;
            }
        }
    }
}