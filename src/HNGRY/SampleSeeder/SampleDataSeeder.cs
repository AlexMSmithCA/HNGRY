namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;

	public class SampleDataSeeder
	{
		private readonly SeedPostedAnswers _seedPostedAnswers;
        private readonly SeedFeedEntries _seedFeedEntries;

        public SampleDataSeeder(SeedPostedAnswers seedPostedAnswers,SeedFeedEntries seedFeedEntries)
		{
			this._seedPostedAnswers = seedPostedAnswers;
            this._seedFeedEntries = seedFeedEntries;
		}

		public async Task InitializeSeedData()
		{
			await _seedPostedAnswers.InsertPostedAnswers();
            await _seedFeedEntries.InsertFeedEntries();
		}
	}
}
