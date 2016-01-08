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
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("hngrymn@gmail.com","bstankey@predictiveTechnologies.com","food arrive","10th");
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            smtp.Credentials = new NetworkCredential("hngrymn@gmail.com", "APT12345");  // [4] Added this. Note, first parameter is NOT string.

            //recipient address
            //mail.To.Add(new MailAddress("bstankey@att.net"));

            //Formatted mail body
            //mail.IsBodyHtml = true;
            //string st = "Test";

            //mail.Body = st;
            smtp.Send(mail);

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

        public async Task UpdateFeedEntry(int id, UpdateFeedEntryChangeType changeType)
        {
            var entry = this.GetFeedEntries().Where(f => f.Id == id).Single();
            if(changeType== UpdateFeedEntryChangeType.Revive)
            {
                entry.Status = true;
                entry.DateConfirmed = DateTime.Now;
            }
            else if (changeType== UpdateFeedEntryChangeType.Confirm)
            {
                entry.NumberConfirms = entry.NumberConfirms + 1;
                entry.DateConfirmed = DateTime.Now;
            }
            else if (changeType == UpdateFeedEntryChangeType.Runout)
            {
                entry.Status = false;
            }
            await this._appContext.SaveChangesAsync();
        }
    }
}
