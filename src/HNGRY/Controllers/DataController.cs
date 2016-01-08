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
		private IEmailSender _emailSender { get; set; }
		private ISmsSender _smsSender { get; set; }

	    public DataController(
			IAppDbRepository appRepository,
			IEmailSender emailSender,
			ISmsSender smsSender)
	    {
		    this._appRepository = appRepository;
		    this._emailSender = emailSender;
		    this._smsSender = smsSender;
	    }

		[HttpPost]
		public async Task<IActionResult> SubmitQuestion(QuestionSubmissionAjaxViewModel model)
		{
			this._emailSender.SendEmail("BStankey@predictiveTechnologies.com", "New HNGRY Question", model.Question);
			await this._appRepository.AddQuestionSubmission(model.Question);

			return new JsonResult(new { Message = "Question submitted!" });
		}

        [HttpPost]
        public async Task<IActionResult> SubmitFood(FoodSubmissionAjaxViewModel model)
        {
			var userUUID = this._appRepository.GetUserFromName(this.User.Identity.Name).Id;
			await this._appRepository.AddFoodSubmission(userUUID, model.Location, model.Message);

	        var user = this._appRepository.GetUserFromUUID(userUUID);
			foreach (var sub in this._appRepository.GetSubscriptions())
			{
				if (sub.EmailAlert && sub.FoodSubmissions && !string.IsNullOrEmpty(user.Email))
				{
					this._emailSender.SendEmail(user.Email, "Food at APT (" + model.Location + ")", model.Message);
				}
				if (sub.TextAlert && sub.FoodSubmissions && !string.IsNullOrEmpty(user.PhoneNumber))
				{
					this._smsSender.SendSms(user.PhoneNumber, "Food at APT (" + model.Location + ") - " + model.Message);
				}
			}

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
