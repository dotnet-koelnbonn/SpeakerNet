using System;
using System.Web.Security;

namespace SpeakerNet.Services.Authorization
{
    public class MembershipService : IMembershipService
    {
        public int MinPasswordLength
        {
            get { return 6; }
        }

        public bool ValidateUser(string userName, string password)
        {
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