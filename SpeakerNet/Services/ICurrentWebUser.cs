using System;
using System.Linq;
using System.Web;
using SpeakerNet.Data;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public interface ICurrentWebUser
    {
        WebUser User { get; }
    }

    public class CurrentWebUser : ICurrentWebUser
    {
        readonly Lazy<WebUser> currentUser;

        public CurrentWebUser(IRepository<WebUser> repository, HttpContextBase httpContext)
        {
            currentUser = new Lazy<WebUser>(() => GetCurrentUser(repository, httpContext));
        }

        static WebUser GetCurrentUser(IRepository<WebUser> repository, HttpContextBase httpContext)
        {
            var user = repository.Entities.Single(u => u.Name == httpContext.User.Identity.Name);
            if (user != null) {
                user = new WebUser(user.Name);
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