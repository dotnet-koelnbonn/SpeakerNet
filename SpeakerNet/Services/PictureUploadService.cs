﻿using System;
using System.Linq;
using System.Web;
using Aperea.Data;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class PictureUploadService : IPictureUploadService
    {
        private readonly IRepository<SpeakerPicture> repository;
        private readonly IRepository<Speaker> speakerRepository;

        public PictureUploadService(IRepository<SpeakerPicture> repository, IRepository<Speaker> speakerRepository)
        {
            this.repository = repository;
            this.speakerRepository = speakerRepository;
        }

        public PictureUploadShowModel TryGetShowModel(Guid speakerId)
        {
            var query = from s in repository.Entities
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
            var query = from s in speakerRepository.Entities
                        where s.Id == speakerId
                        select new PictureUploadUploadModel {
                            SpeakerId = s.Id,
                            SpeakerName = s.FirstName + " " + s.LastName
                        };
            return query.Single();
        }

        public bool SavePicture(Guid speakerId, HttpPostedFileBase picture)
        {
            var speaker = speakerRepository.Entities.Single(s => s.Id == speakerId);
            ClearCurrentPicturesFromSpeaker(speaker);
            AddPictureToRepository(speaker, picture);
            repository.SaveChanges();
            return true;
        }

        private void AddPictureToRepository(Speaker speaker, HttpPostedFileBase picture)
        {
            repository.Add(new SpeakerPicture {
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
            var query = repository.Entities.Where(sp => sp.Speaker.Id == speaker.Id);
            foreach (var speakerPicture in query) {
                speakerPicture.CurrentPicture = false;
            }
        }
    }
}