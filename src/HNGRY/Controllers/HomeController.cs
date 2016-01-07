using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HNGRY.Models;
using Microsoft.AspNet.Mvc;

namespace HNGRY.Controllers
{
    public class HomeController : Controller
    {
		public AppDbContext _appContext { get; set; }

	    public HomeController(AppDbContext appContext)
	    {
		    this._appContext = appContext;
	    }

        public IActionResult Index()
        {
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
		public IActionResult SubmitQuestion(SubmitQuestionModel model)
		{
			this._appContext.Add(new QuestionSubmission
			{
				QuestionText = model.Text
			});
			this._appContext.SaveChanges();


			return null;
	    }

	    public class SubmitQuestionModel
	    {
		    public string Text { get; set; }
		}

	}
}
