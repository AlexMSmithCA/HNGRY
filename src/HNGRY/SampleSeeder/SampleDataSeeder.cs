namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;

	public class SampleDataSeeder
	{
		private readonly SeedPostedAnswers _seedPostedAnswers;

		public SampleDataSeeder(SeedPostedAnswers seedPostedAnswers)
		{
			this._seedPostedAnswers = seedPostedAnswers;
		}

		public async Task InitializeSeedData()
		{
			await _seedPostedAnswers.InsertPostedAnswers();
		}
	}
}
