namespace HNGRY.Controllers
{
	using System.Threading.Tasks;
	using HNGRY.Services;
	using Microsoft.AspNet.Mvc;
	using HNGRY.ViewModels.Ajax;
	using HNGRY.Attributes;
	using Microsoft.AspNet.Authorization;

	[Authorize]
	[AutoLogin]
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
			await this._appRepository.AddQuestionSubmission(model.Question);

			//var myQs = this._appRepository.GetQuestionSubmissions();

			return new JsonResult(new { Message = "Question submitted!" });
		}

        [HttpPost]
        public async Task<IActionResult> SubmitFood(FoodSubmissionAjaxViewModel model)
        {
			var userUUID = this._appRepository.GetUserFromName(this.User.Identity.Name).Id;
			await this._appRepository.AddFoodSubmission(userUUID, model.Location, model.Message);

            return new JsonResult(new { Message = "Food submitted!" });
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeAjaxViewModel model)
        {
	        var userUUID = this._appRepository.GetUserFromName(this.User.Identity.Name).Id;
            await this._appRepository.AddSubscriber(
				userUUID,
				model.Name,
				model.Email,
				model.Phone,
				model.EmailAlert,
				model.TextAlert,
				model.FoodSubmissions,
				model.PostsFrom);

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
			var userUUID = this._appRepository.GetUserFromName(this.User.Identity.Name).Id;
			await this._appRepository.AddPostedAnswer(userUUID, model.Title, model.Author, model.Message);

            return new JsonResult(new { Message = "Feed Entry Updated" });
        }

    }
}
