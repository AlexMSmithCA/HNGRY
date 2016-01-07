namespace HNGRY.Controllers
{
	using System.Threading.Tasks;
	using HNGRY.Services;
	using Microsoft.AspNet.Mvc;
	using HNGRY.ViewModels.Ajax;

	public class DataController : Controller
    {
		private IAppDbRepository _appRepository { get; set; }

	    public DataController(IAppDbRepository appRepository)
	    {
		    this._appRepository = appRepository;
	    }

		[HttpPost]
		public async Task<IActionResult> SubmitQuestion(QuestionSubmissionAjaxViewModel model)
		{
			await this._appRepository.AddQuestionSubmission(model.Text);

			var myQs = this._appRepository.GetQuestionSubmissions();

			return new JsonResult(new { Message = "Question submitted!" });
		}
	}
}
