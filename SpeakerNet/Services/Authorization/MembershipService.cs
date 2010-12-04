using System;
using System.Web.Security;
using SpeakerNet.Settings;

namespace SpeakerNet.Services.Authorization
{
    public class MembershipService : IMembershipService
    {
        private readonly IAuthenticationSettings settings;

        public MembershipService(IAuthenticationSettings settings)
        {
            this.settings = settings;
        }

        public int MinPasswordLength
        {
            get { return 6; }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (userName != settings.Username)
                return false;
            if (password != settings.Password)
                return false;
            return true;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}