namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;
	using System.Linq;
	using HNGRY.Services;

	public class SeedFeedEntries
	{
		private readonly IAppDbRepository _appRepository;

		public SeedFeedEntries(IAppDbRepository appRepository)
		{
			this._appRepository = appRepository;
		}

		public async Task InsertFeedEntries()
		{
			if (!this._appRepository.GetFeedEntries().Any())
			{
				await this._appRepository.AddFoodSubmission("10th Floor","Clam chowder");
                await this._appRepository.AddFoodSubmission("11th Floor", "Tomato paste");
                await this._appRepository.AddFoodSubmission("91th Floor", "Chopped Panda");
            }
		}
	}
}