using System;
using Aperea;

namespace SpeakerNet.Services
{
    public interface IActionUrlBuilder
    {
        string GetActionUrl([AspMvcAction] string action, [AspMvcController] string controller);
        string GetActionUrl([AspMvcAction] string action, [AspMvcController] string controller, object routeValues);
    }
}