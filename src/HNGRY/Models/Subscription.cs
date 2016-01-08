namespace HNGRY.Models
{
	using System;
    using System.ComponentModel.DataAnnotations;

	public class Subscription
    {
        [Key]
        public string AccountID { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public int FoodSubmissions { get; set; }

        public int PostsFrom { get; set; }

        public int EmailAlert { get; set; }

        public int TextAlert { get; set; }
    }
}
