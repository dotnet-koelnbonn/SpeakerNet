using System.Web.Mvc;
using SpeakerNet.Security;

namespace SpeakerNet.FilterAttributes
{
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        public AdminOnlyAttribute()
        {
//            Roles = SecurityRoles.Administrator;
        }
    }
}