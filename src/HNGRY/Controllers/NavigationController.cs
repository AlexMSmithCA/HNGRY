﻿namespace HNGRY.Controllers
{

    using System.Threading.Tasks;
    using HNGRY.Services;
	using HNGRY.ViewModels;
	using Microsoft.AspNet.Mvc;
	using System.Linq;

	public class NavigationController : Controller
    {
		private IAppDbRepository _appRepository { get; set; }

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
                    AuthorName = a.AuthorName,
                    DateSubmittedDisplayString = a.DateSubmitted.ToString("hh:mm tt"),                    
                    Message = a.Message,
                    DateConfirmedDisplayString = a.DateConfirmed.ToString("hh:mm tt"),
                    Location = a.Location,
                    Status = a.Status,
                    TimeSinceConfirm = (int)System.DateTime.Now.Subtract(a.DateConfirmed).TotalMinutes,
                    NumberConfirms = a.NumberConfirms
                }).OrderByDescending(f => f.DateSubmittedDisplayString)
                .ToList()
            };


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

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

        public IActionResult Error()
        {
            return View();
        }
	}
}
