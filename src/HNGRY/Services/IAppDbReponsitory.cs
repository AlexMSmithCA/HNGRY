namespace HNGRY.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using HNGRY.Models;

	public interface IAppDbRepository
	{
		List<User> GetUsers();
		User GetUserFromName(string username);
		User GetUserFromUUID(string userUUID);

		List<QuestionSubmission> GetQuestionSubmissions();
	    Task AddQuestionSubmission(string question);

		List<PostedAnswer> GetPostedAnswers();
		Task AddPostedAnswer(string userUUID, string title, string authorName, string message);

        List<FeedEntry> GetFeedEntries();
        Task UpdateFeedEntry(int id, UpdateFeedEntryChangeType changeType);

        Task AddFoodSubmission(string userUUID, string location, string message);

		Task AddSubscriber(string userUUID, string name, string email, string phone, bool emailAlert, bool textAlert,
			bool foodSubmissions, bool postsFrom);
		Subscription GetSubscriptionForUser(string userUUID);
		List<Subscription> GetSubscriptions();
	}
}
