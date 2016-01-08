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

		#region User Methods
		public List<User> GetUsers()
	    {
		    return this._appContext.Users.ToList();
	    }

	    public User GetUserFromName(string username)
	    {
		    return this.GetUsers().SingleOrDefault(u => u.UserName == username);
	    }

	    public User GetUserFromUUID(string userUUID)
	    {
		    return this.GetUsers().SingleOrDefault(u => u.Id == userUUID);
	    }
		#endregion

		#region QuestionSubmission Methods
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
		#endregion

		#region PostedAnswers Region
		public List<PostedAnswer> GetPostedAnswers()
	    {
		    return this._appContext.PostedAnswers.ToList();
	    }
	    public async Task AddPostedAnswer(string userUUID, string title, string authorName, string message)
	    {
		    var user = this.GetUserFromUUID(userUUID);

		    var smtp = new SmtpClient
		    {
			    Host = "smtp.gmail.com",
			    Port = 587,
			    EnableSsl = true,
			    DeliveryMethod = SmtpDeliveryMethod.Network,
			    UseDefaultCredentials = false,
			    Credentials = new NetworkCredential("hngrymn@gmail.com", "APT12345")
		    };

		    foreach (var sub in GetSubscriptions())
            {
                if (sub.EmailAlert && sub.PostsFrom)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("hngrymn@gmail.com", user.Email, "New Post from " + authorName + " about " + title, message);
                    smtp.Send(mail);
                }
                if (sub.TextAlert && sub.PostsFrom)
                {
                    System.Net.Mail.MailMessage text = new System.Net.Mail.MailMessage("hngrymn@gmail.com", user.PhoneNumber, "New Post from " + authorName + " about " + title, message);
                    smtp.Send(text);
                    //System.Net.Mail.MailMessage text2 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone + "@@txt.att.net", "Food at APT (" + locationA + ")", messageA);
                    //smtp.Send(text2);                    
                }
                //System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Email, "Food at APT (" + locationA + ")", messageA);
                //smtp.Send(mail1);
                //System.Net.Mail.MailMessage text1 = new System.Net.Mail.MailMessage("hngrymn@gmail.com", sub.Phone.ToString() + "@vtext.com", "Food at APT (" + locationA + ")", messageA);
                //smtp.Send(text1);
            }


            this._appContext.Add(new PostedAnswer
			{
                Title = title,
                AuthorName = authorName,
				Message = message,
				DateSubmitted = DateTime.Now
			});
			await this._appContext.SaveChangesAsync();
		}
		#endregion

		#region FeedEntry Region
		public List<FeedEntry> GetFeedEntries()
        {
            return this._appContext.FeedEntries.ToList();
        }
		public async Task UpdateFeedEntry(int id, UpdateFeedEntryChangeType changeType)
		{
			var entry = this.GetFeedEntries().Where(f => f.Id == id).Single();
			if (changeType == UpdateFeedEntryChangeType.Revive)
			{
				entry.Status = true;
				entry.DateConfirmed = DateTime.Now;
			}
			else if (changeType == UpdateFeedEntryChangeType.Confirm)
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
		#endregion

		#region FoodSubmission Region
		public async Task AddFoodSubmission(string userUUID, string location, string message)
        {
            this._appContext.Add(new FeedEntry
            {
				UserUUID = userUUID,
                Location = location,
                Message = message,
                DateSubmitted = DateTime.Now,
                DateConfirmed = DateTime.Now,
                Status = true,
                NumberConfirms = 1
            });
            await this._appContext.SaveChangesAsync();
        }
		#endregion

		#region Subscriber Region
		public async Task AddSubscriber(string userUUID, string name, string email, string phone, bool emailAlert, bool textAlert, bool foodSubmissions, bool postsFrom)
        {
	        if (string.IsNullOrEmpty(userUUID)) throw new ArgumentException("UserUUID must be popualted");

	        var user = GetUserFromUUID(userUUID);
			user.PhoneNumber = phone;
	        user.Email = email;

			// If a subscription already exists, we can re-use it.  Otherwise, we create a new one.
	        if (this._appContext.Subscriptions.Any(s => s.UserUUID == userUUID))
	        {
		        var subscription = this._appContext.Subscriptions.Single(s => s.UserUUID == userUUID);
		        subscription.FoodSubmissions = foodSubmissions;
		        subscription.PostsFrom = postsFrom;
		        subscription.EmailAlert = emailAlert;
		        subscription.TextAlert = textAlert;
	        }
	        else
	        {
				this._appContext.Add(new Subscription
				{
					UserUUID = userUUID,
					FoodSubmissions = foodSubmissions,
					PostsFrom = postsFrom,
					EmailAlert = emailAlert,
					TextAlert = textAlert
				});
			}

            await this._appContext.SaveChangesAsync();
        }
		public Subscription GetSubscriptionForUser(string userUUID)
		{
			return this._appContext.Subscriptions.SingleOrDefault(s => s.UserUUID == userUUID);
		}
		public List<Subscription> GetSubscriptions()
		{
			return this._appContext.Subscriptions.ToList();
		}
		#endregion
	}
}
