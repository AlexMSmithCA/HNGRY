namespace HNGRY.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using HNGRY.Models;

	public interface IAppDbRepository
	{
		List<User> GetUsers();
		User GetUserFromName(string username);

		List<QuestionSubmission> GetQuestionSubmissions();
	    Task AddQuestionSubmission(string question);

		List<PostedAnswer> GetPostedAnswers();
		Task AddPostedAnswer(string title, string authorName, string message);

        List<FeedEntry> GetFeedEntries();
        Task UpdateFeedEntry(int id, UpdateFeedEntryChangeType changeType);

        Task AddFoodSubmission(string locationA, string messageA);

        Task AddSubscriber(string phone, int foodSubmissions, string email, int postsFrom, int emailAlert, int textAlert);


    }
}
