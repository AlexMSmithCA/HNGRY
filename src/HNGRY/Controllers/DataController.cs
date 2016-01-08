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

        [HttpPost]
        public async Task<IActionResult> SubmitFood(FoodSubmissionAjaxViewModel model)
        {
            await this._appRepository.AddFoodSubmission(model.Location, model.Message);

            return new JsonResult(new { Message = "Food submitted!" });
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeAjaxViewModel model)
        {
            await this._appRepository.AddSubscriber(model.Phone, model.FoodSubmissions, model.Email, model.PostsFrom, model.EmailAlert, model.TextAlert);

            return new JsonResult(new { Message = "Subscription Updated" });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeedEntry(UpdateFeedEntryAjaxViewModel model)
        {
            await this._appRepository.UpdateFeedEntry(model.Id, model.ChangeType);

            return new JsonResult(new { Message = "Feed Entry Updated" });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitResponse(SubmitResponseAjaxViewModel model)
        {
            await this._appRepository.AddPostedAnswer(model.Title, model.Author, model.Message);

            return new JsonResult(new { Message = "Feed Entry Updated" });
        }

    }
}
