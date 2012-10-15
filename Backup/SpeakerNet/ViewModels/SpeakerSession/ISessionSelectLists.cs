using System.Web.Mvc;

namespace SpeakerNet.ViewModels
{
    public interface ISessionSelectLists {
        SelectList EventSelectList { get; set; }
        SelectList LevelSelectList { get; set; }
        SelectList DurationSelectList { get; set; }
    }
}