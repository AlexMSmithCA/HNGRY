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

	    public async Task AddPostedAnswer(string title, string authorName, string message)
	    {
			this._appContext.Add(new PostedAnswer
			{
                Title = title,
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
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hngrymn@gmail.com", "APT12345");

            foreach (Subscription sub in GetSubscriptions())
            {
                if (sub.EmailAlert == 1 && sub.FoodSubmissions == 1)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Email, "Food at APT (" + locationA + ")", messageA);
                    smtp.Send(mail);
                }
                if (sub.TextAlert == 1 && sub.FoodSubmissions == 1)
                {
                    System.Net.Mail.MailMessage text = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone +"@vtext.com", "Food at APT (" + locationA + ")", messageA);
                    smtp.Send(text);
                    //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
                    //smtp.Send(text2);                    
                }
                //System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Email, "Food at APT (" + locationA + ")", messageA);
                //smtp.Send(mail1);
                //System.Net.Mail.MailMessage text1 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone.ToString() + "@vtext.com", "Food at APT (" + locationA + ")", messageA);
                //smtp.Send(text1);
            }


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

        public async Task AddSubscriber(string phone, int foodSubmissions, string email, int postsFrom, int emailAlert, int textAlert)
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
                entry.DateConfirmed = DateTime.Now;
            }
            await this._appContext.SaveChangesAsync();
        }

        public List<Subscription> GetSubscriptions()
        {
            return this._appContext.Subscriptions.ToList();
        }
    }
}
