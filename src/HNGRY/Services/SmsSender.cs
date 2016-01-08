namespace HNGRY.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Net;
	using System.Net.Mail;

	public class SmsSender : ISmsSender
    {
		private const string _hostEmail = "hngrymn@gmail.com";
		private const string _hostPassword = "APT12345";

		public void SendSms(string number, string message)
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

            var smtp1 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_hostEmail, _hostPassword)
            };

            var smtp2 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_hostEmail, _hostPassword)
            };

            var smtp3 = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_hostEmail, _hostPassword)
            };
            var text = new System.Net.Mail.MailMessage(_hostEmail, number + "@txt.att.net", string.Empty, message);
            //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
            smtp.Send(text);

            var text1 = new System.Net.Mail.MailMessage(_hostEmail, number + "@vtext.com", string.Empty, message);
            //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
            smtp1.Send(text1);

            var text2 = new System.Net.Mail.MailMessage(_hostEmail, number + "@messaging.sprintpcs.com", string.Empty, message);
            //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
            smtp2.Send(text2);

            var text3 = new System.Net.Mail.MailMessage(_hostEmail, number + "@tmomail.net", string.Empty, message);
            //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
            smtp3.Send(text3);
        }
	}
}
