using System.ComponentModel.DataAnnotations.Schema;

namespace HNGRY.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class Email
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public int MessageNumber { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateSent { get; set; }

    }
}
