namespace HNGRY.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HNGRY.Models;
    using System.Text;
    using System.Net.Mail;
    using System.Net;

    public class AppDbRepository : IAppDbRepository
    {
	    public AppDbContext _appContext;

	    public AppDbRepository(AppDbContext appContext)
	    {
		    this._appContext = appContext;

	    }
	    public List<QuestionSubmission> GetQuestionSubmissions()
	    {
		    return this._appContext.QuestionSubmissions.ToList();
	    }

	    public async Task AddQuestionSubmission(string question)
	    {
		    this._appContext.Add(new QuestionSubmission
		    {
				QuestionText = question
		    });
		    await this._appContext.SaveChangesAsync();
	    }

	    public List<PostedAnswer> GetPostedAnswers()
	    {
		    return this._appContext.PostedAnswers.ToList();
	    }

	    public async Task AddPostedAnswer(string authorName, string message)
	    {
			this._appContext.Add(new PostedAnswer
			{
				AuthorName = authorName,
				Message = message,
				DateSubmitted = DateTime.Now
			});
			await this._appContext.SaveChangesAsync();
		}

        public List<FeedEntry> GetFeedEntries()
        {
            return this._appContext.FeedEntries.ToList();
        }

        public async Task AddFoodSubmission(string locationA, string messageA)
        {
            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("", "kht.ngo@gmail.com", "subject","body");

            ////System.Web.Mail.SmtpMail.SmtpServer = "SMTP Server Address";
            ////System.Web.Mail.SmtpMail.Send(message);
            //client.Host = "smtp.gmail.com";
            //client.Port = 587;
            //client.EnableSSL = true;
            //client.Credentials = new NetworkCredential("yourname@gmail.com", "password");
            ////MailMessage mail = new MailMessage();
            ////mail.From = new System.Net.Mail.MailAddress("kht.ngo@gmail.com");

            //// The important part -- configuring the SMTP client
            //SmtpClient smtp = new SmtpClient();
            //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;


            ////recipient address
            ////mail.To.Add(new MailAddress("bstankey@att.net"));

            ////Formatted mail body
            ////mail.IsBodyHtml = true;
            ////string st = "Test";

            ////mail.Body = st;
            //smtp.Send(mail);

            this._appContext.Add(new FeedEntry
            {
                Location = locationA,
                Message = messageA,
                DateSubmitted = DateTime.Now,
                DateConfirmed = DateTime.Now,
                Status = true,
                AuthorName = "Sean",
                NumberConfirms = 1

            });
            await this._appContext.SaveChangesAsync();

        }

        public async Task AddSubscriber(int phone, int foodSubmissions, string email, int postsFrom, int emailAlert, int textAlert)
        {
            this._appContext.Add(new Subscription
            {
                Phone= phone,
                FoodSubmissions = foodSubmissions,
                Email = email,
                PostsFrom = postsFrom,
                EmailAlert = emailAlert,
                TextAlert = textAlert
            });
            await this._appContext.SaveChangesAsync();
        }

    }
}
