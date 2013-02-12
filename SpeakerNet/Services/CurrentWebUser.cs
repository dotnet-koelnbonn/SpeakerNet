using System;
using System.Linq;
using System.Web;
using Aperea.Data;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public class CurrentWebUser : ICurrentWebUser
    {
        readonly Lazy<WebUser> currentUser;

        public CurrentWebUser(IRepository<WebUser> repository, HttpContextBase httpContext)
        {
            currentUser = new Lazy<WebUser>(() => GetCurrentUser(repository, httpContext));
        }

        static WebUser GetCurrentUser(IRepository<WebUser> repository, HttpContextBase httpContext)
        {
            var user = repository.Entities.SingleOrDefault(u => u.Name == httpContext.User.Identity.Name.Trim());
            if (user == null) {
                user = new WebUser(httpContext.User.Identity.Name.Trim());
                repository.Add(user);
                repository.SaveChanges();
            }
            return user;
        }

        public WebUser User
        {
            get { return currentUser.Value; }
        }
    }
}