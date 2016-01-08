namespace HNGRY.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HNGRY.Models;

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
