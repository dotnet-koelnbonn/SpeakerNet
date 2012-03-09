using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpeakerNet.Services
{
    public class ActionUrlBuilder : IActionUrlBuilder
    {
        readonly HttpContextBase httpContext;
        readonly HttpRequestBase httpRequest;

        public ActionUrlBuilder(HttpContextBase httpContext, HttpRequestBase httpRequest)
        {
            this.httpContext = httpContext;
            this.httpRequest = httpRequest;
        }

        public string GetActionUrl(string action, string controller)
        {
            return GetActionUrl(action, controller, null);
        }

        public string GetActionUrl(string action, string controller, object routeValues)
        {
            return string.Format("{0}{1}",
                GetBaseUrl(),
                GetUrlHelper().Action(action, controller, routeValues));
        }

        UrlHelper GetUrlHelper()
        {
            return new UrlHelper(CreateRequestContext());
        }

        string GetBaseUrl()
        {
            return string.Format("{0}://{1}", httpRequest.Url.Scheme, httpRequest.Url.Authority);
        }

        RequestContext CreateRequestContext()
        {
            return new RequestContext(httpContext, RouteTable.Routes.GetRouteData(httpContext));
        }
    }
}