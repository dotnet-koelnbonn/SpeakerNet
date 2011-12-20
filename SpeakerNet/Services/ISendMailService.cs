namespace SpeakerNet.Services
{
    public interface ISendMailService
    {
        void SendMail(string to, string subject, string body);
    }
}