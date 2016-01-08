namespace HNGRY.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using HNGRY.Models;

	public interface IAppDbRepository
    {
	    List<QuestionSubmission> GetQuestionSubmissions();
	    Task AddQuestionSubmission(string question);

		List<PostedAnswer> GetPostedAnswers();
		Task AddPostedAnswer(string title, string authorName, string message);

        List<FeedEntry> GetFeedEntries();
        Task UpdateFeedEntry(int id, UpdateFeedEntryChangeType changeType);

        Task AddFoodSubmission(string locationA, string messageA);

        Task AddSubscriber(int phone, int foodSubmissions, string email, int postsFrom, int emailAlert, int textAlert);


    }
}
