using System;
using System.Web;
using System.Web.Mvc;

namespace SpeakerNet.Web
{
    public interface IAdaptiveViewEngine : IViewEngine
    {
        Func<HttpContextBase, bool> IsTheRightDevice { get; }
        string PathToSearch { get;}
    }
}