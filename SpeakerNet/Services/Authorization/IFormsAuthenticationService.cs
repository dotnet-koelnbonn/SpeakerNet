namespace SpeakerNet.Services.Authorization
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}