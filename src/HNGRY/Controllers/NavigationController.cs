namespace HNGRY.Controllers
{
    using HNGRY.Services;
	using Microsoft.AspNet.Authorization;
	using HNGRY.ViewModels;
	using Microsoft.AspNet.Mvc;
	using System.Linq;
	using HNGRY.Attributes;
	using System.Security.Claims;

	[Authorize]
	[AutoLogin]
	public class NavigationController : Controller
	{
		private readonly IAppDbRepository _appRepository;

		public NavigationController(IAppDbRepository appRepository)
	    {

		    this._appRepository = appRepository;
	    }

		public IActionResult Index()
        {
	        ViewData["PostedAnswersViewModel"] = new PostedAnswersViewModel
	        {
		        Answers = this._appRepository.GetPostedAnswers().Select(a => new PostedAnswerViewModel
						{
                            Title=a.Title, 
                            AuthorName = a.AuthorName,
							DateSubmittedDisplayString = a.DateSubmitted.ToString(),
							Message = a.Message
						})
					.ToList()
	        };

            ViewData["FeedEntriesViewModel"] = new FeedEntriesViewModel
            {
                FeedEntries = this._appRepository.GetFeedEntries().Select(a => new FeedEntryViewModel
                {
                    Id = a.Id,
                    AuthorName = a.AuthorName,
                    DateSubmittedDisplayString = a.DateSubmitted.ToString("hh:mm tt"),                    
                    Message = a.Message,
                    DateConfirmedDisplayString = a.DateConfirmed.ToString("hh:mm tt"),
                    Location = a.Location,
                    Status = a.Status,
                    TimeSinceConfirm = (int)System.DateTime.Now.Subtract(a.DateConfirmed).TotalMinutes,
                    NumberConfirms = a.NumberConfirms,
                    TimeOrder = a.DateSubmitted.Ticks
                }).OrderByDescending(f => f.TimeOrder)
                .ToList()
            };


            return View();
        }

		[AllowAnonymous]
		public IActionResult About()
        {
            ViewData["Message"] = $"Your application description page. -- {User.Identity.Name} SignedIn{User.IsSignedIn()} UserId{User.GetUserId()} Auth{User.Identity.IsAuthenticated}";

            return View();
        }

		[AllowAnonymous]
		public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Subscribe()
        {
            ViewData["Message"] = "Subscribe to Go/Food";

            return View();
        }
        public IActionResult ResponseForm()
        {
            ViewData["Message"] = "Post question responses";

            return View();
        }

		[AllowAnonymous]
		public IActionResult Error()
        {
            return View();
        }
	}
}
