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

	    public async Task AddFoodSubmission(string locationA, string messageA)
        {
            this._appContext.Add(new FeedEntry
            {
                Location = locationA,
                Message = messageA
            });
            await this._appContext.SaveChangesAsync();
        }
    }
}
