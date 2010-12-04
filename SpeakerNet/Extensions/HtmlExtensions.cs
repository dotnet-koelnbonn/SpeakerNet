using System.Web;
using System.Web.Mvc;
using WikiPlex;

namespace SpeakerNet.Extensions
{
    public static class HtmlExtensions
    {

        public static IHtmlString Raw(this HtmlHelper<string> htmlHelper, string html)
        {
            return new HtmlString(html);
        }

        public static IHtmlString Wiki(this HtmlHelper<string> htmlHelper, string wikiContent)
        {
            var wiki = new WikiEngine();
            return new HtmlString(wiki.Render(wikiContent));
        }
    }
}