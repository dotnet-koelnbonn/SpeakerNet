using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SpeakerNet.Models;
using SpeakerNet.Models.Views;

namespace SpeakerNet.Extensions
{
    public static class SpeakerNavigation
    {
        public static IHtmlString EditSpeaker(this HtmlHelper htmlHelper, string caption, Speaker speaker)
        {
            return htmlHelper.ActionLink(caption, "Edit", "Speaker", new
            {
                id = speaker.Id
            }, null);
        }

        public static IHtmlString CreateSpeaker(this HtmlHelper htmlHelper, string caption)
        {
            return htmlHelper.ActionLink(caption, "Create", "Speaker");
        }

        public static IHtmlString ShowSpeaker(this HtmlHelper htmlHelper, string caption, SpeakerListModel model)
        {
            return htmlHelper.ActionLink(caption, "Details", "Speaker", new
            {
                id = model.Id
            }, null);
        }

        public static IHtmlString SpeakerList(this HtmlHelper htmlHelper, string caption)
        {
            return htmlHelper.ActionLink(caption, "List", "Speaker");
        }
    }
}