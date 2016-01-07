namespace HNGRY.Controllers
{
	using System.Threading.Tasks;
	using HNGRY.Services;
	using HNGRY.ViewModels;
	using Microsoft.AspNet.Mvc;
	using System.Collections.Generic;
	using HNGRY.Models;

	public class NavigationController : Controller
    {
		private IAppDbRepository _appRepository { get; set; }

	    public NavigationController(IAppDbRepository appRepository)
	    {
		    this._appRepository = appRepository;
	    }

        public IActionResult Index()
        {
            ViewData["PostedAnswers"] = new List<PostedAnswer>
            {
                new PostedAnswer
                {
                    AuthorName = "Dale",
                    Message = "No more dunkaroos",
                    Question = new QuestionSubmission {QuestionText = "WHY DONT WE HAVE DUNKAROOS?" }
                },
                new PostedAnswer
                {
                    AuthorName = "Dale",
                    Message = "No more dunkaroos seriously",
                    Question = new QuestionSubmission {QuestionText = "Why don't we have those dunking snacks?" }
                }
            };

            //ViewData["PostedAnswers2"] = this._appContext.PostedAnswers.ToList();
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

        public IActionResult Error()
        {
            return View();
        }
	}
}
