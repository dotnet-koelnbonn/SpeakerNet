using System.Collections.Generic;

namespace SpeakerNet.ViewModels
{
    public class DetailsEventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SessionListModel> Session { get; set; }
    }
}