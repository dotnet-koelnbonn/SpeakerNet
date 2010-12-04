using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Extensions
{
    public static class SpeakerNavigation
    {
        public static IHtmlString EditSpeaker(this HtmlHelper htmlHelper, string caption, SpeakerEditModel speaker)
        {
            return htmlHelper.ActionLink(caption, "Edit", "Speaker", new {
                id = speaker.Id
            }, null);
        }

        public static IHtmlString CreateSpeaker(this HtmlHelper htmlHelper, string caption)
        {
            return htmlHelper.ActionLink(caption, "Create", "Speaker");
        }

        public static IHtmlString ShowSpeaker(this HtmlHelper htmlHelper, string caption, SpeakerListModel model)
        {
            return htmlHelper.ActionLink(caption, "Details", "Speaker", new {
                id = model.Id
            }, null);
        }

        public static IHtmlString ShowSpeakerLinks(this HtmlHelper htmlHelper, SpeakerListModel model)
        {
            var zeigen= htmlHelper.ActionLink("Zeigen", "Details", "Speaker", new
            {
                id = model.Id
            }, null);

            var sessions = htmlHelper.ActionLink("Sessions", "List", "SpeakerSession", new
            {
                speakerid = model.Id
            }, null);

            return new HtmlString(string.Format("{0} | {1}",zeigen,sessions));
        }

        public static IHtmlString SpeakerList(this HtmlHelper htmlHelper, string caption)
        {
            return htmlHelper.ActionLink(caption, "List", "Speaker");
        }
    }
}