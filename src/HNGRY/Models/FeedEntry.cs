namespace HNGRY.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class FeedEntry
    {
		[Key]
		public int Id { get; set; }
		public string AuthorName { get; set; }

		public string Message { get; set; }

		public DateTime DateSubmitted { get; set; }

        public DateTime DateConfirmed { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

    }
}
