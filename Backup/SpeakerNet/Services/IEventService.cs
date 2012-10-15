using System.Collections.Generic;
using System.Web.Mvc;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface IEventService
    {
        IEnumerable<EventListModel> GetEventList();
        void CreateEvent(CreateEventModel model);
        EditEventModel GetEditEventModel(int eventId);
        void UpdateEvent(int eventId, EditEventModel model);
        DetailsEventModel GetDetailsEventModel(int eventId);
    }
}