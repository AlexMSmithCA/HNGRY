namespace HNGRY.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using HNGRY.Models;

	public interface IAppDbRepository
    {
	    List<QuestionSubmission> GetQuestionSubmissions();
	    Task AddQuestionSubmission(string question);
        Task AddFoodSubmission(string locationA, string messageA);
        Task AddSubscriber(int phone, int foodSubmissions, string email, int postsFrom, int emailAlert, int textAlert);
    }
}
