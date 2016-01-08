using System.ComponentModel.DataAnnotations.Schema;

namespace HNGRY.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class FeedEntry
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string UserUUID { get; set; }

		public string Message { get; set; }

		public DateTime DateSubmitted { get; set; }

        public DateTime DateConfirmed { get; set; }

        public string Location { get; set; }

        public bool Status { get; set; }

        public int NumberConfirms { get; set; }

    }
}
