namespace HNGRY.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Subscription
    {
        [Key]
		public int SubscriptionId { get; set; }

        public string UserUUID { get; set; }

		public bool EmailAlert { get; set; }

		public bool TextAlert { get; set; }

		public bool FoodSubmissions { get; set; }

        public bool PostsFrom { get; set; }
    }
}
