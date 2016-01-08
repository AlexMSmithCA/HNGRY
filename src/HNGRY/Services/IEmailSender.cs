namespace HNGRY.Services
{
	public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }
}
