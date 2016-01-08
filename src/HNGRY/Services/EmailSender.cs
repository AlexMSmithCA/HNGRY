namespace HNGRY.Services
{
	using System.Net;
	using System.Net.Mail;


	public class EmailSender : IEmailSender
    {
		private const string _hostEmail = "hngrymn@gmail.com";
		private const string _hostPassword = "APT12345";

		public void SendEmail(string email, string subject, string message)
	    {
			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(_hostEmail, _hostPassword)
			};                        
            var mail = new System.Net.Mail.MailMessage(_hostEmail, email, subject, message + "Reply " + " " + "if the food is gone!");
			smtp.Send(mail);
		}
    }
}
