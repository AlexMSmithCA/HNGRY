namespace HNGRY.ViewModels.Ajax
{
    public class SubscribeAjaxViewModel
    {
		public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

		public bool EmailAlert { get; set; }

		public bool TextAlert { get; set; }

		public bool FoodSubmissions { get; set; }

        public bool PostsFrom { get; set; }
    }
}
