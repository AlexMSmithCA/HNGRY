namespace HNGRY.ViewModels
{
	using System.Collections.Generic;

	public class PostedAnswersViewModel
	{
		public List<PostedAnswerViewModel> Answers { get; set; }
	}

	public class PostedAnswerViewModel
    {
		public string AuthorName { get; set; }

		public string Message { get; set; }

		public string DateSubmittedDisplayString { get; set; }
	}
}
