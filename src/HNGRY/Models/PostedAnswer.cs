namespace HNGRY.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostedAnswer
    {
        [Key]
        public int Id { get; set; }

        public string AuthorName { get; set; }

		public string Message { get; set; }

		public DateTime DateSubmitted { get; set; }
    }
}
