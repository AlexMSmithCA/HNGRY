namespace HNGRY.Models
{
	using System;

    public class FeedEntry
    {
		public string AuthorName { get; set; }

		public string Message { get; set; }

		public DateTime DateSubmitted { get; set; }

		public string Location { get; set; }
    }
}
