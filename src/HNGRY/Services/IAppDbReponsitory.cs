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

        Task AddFoodSubmission(string locationA, string messageA);
    }
}
