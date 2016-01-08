namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;

	public class SampleDataSeeder
	{
		private readonly SeedPostedAnswers _seedPostedAnswers;
        private readonly SeedFeedEntries _seedFeedEntries;
		private readonly SeedUsers _seedUsers;

        public SampleDataSeeder(
			SeedPostedAnswers seedPostedAnswers,
			SeedFeedEntries seedFeedEntries,
			SeedUsers seedUsers)
		{
			this._seedPostedAnswers = seedPostedAnswers;
            this._seedFeedEntries = seedFeedEntries;
	        this._seedUsers = seedUsers;
		}

		public async Task InitializeSeedData()
		{
			await _seedUsers.InsertUsers();
			await _seedPostedAnswers.InsertPostedAnswers();
            await _seedFeedEntries.InsertFeedEntries();
		}
	}
}
