namespace HNGRY.ViewModels
{
	using System.Collections.Generic;

	public class FeedEntriesViewModel
	{
		public List<FeedEntryViewModel> FeedEntries { get; set; }
	}

	public class FeedEntryViewModel
    {
        public string AuthorName { get; set; }

        public string Message { get; set; }

        public string DateSubmittedDisplayString { get; set; }

        public string DateConfirmedDisplayString { get; set; }

        public string Location { get; set; }

        public bool Status { get; set; }

        public int NumberConfirms { get; set; }

        public int TimeSinceConfirm { get; set; }


    }
}
