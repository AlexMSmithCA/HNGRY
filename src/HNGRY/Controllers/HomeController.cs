namespace HNGRY.Controllers
{
	using System.Threading.Tasks;
	using HNGRY.Services;
	using HNGRY.ViewModels;
	using Microsoft.AspNet.Mvc;
	using System.Collections.Generic;
	using HNGRY.Models;

	public class HomeController : Controller
    {
		private IAppDbRepository _appRepository { get; set; }

	    public HomeController(IAppDbRepository appRepository)
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

		[HttpPost]
		public async Task<IActionResult> SubmitQuestion(QuestionSubmissionViewModel model)
		{
			await this._appRepository.AddQuestionSubmission(model.Text);

			var myQs = this._appRepository.GetQuestionSubmissions();

			return new JsonResult(new { Message = "Question submitted!" });
		}
	}
}
