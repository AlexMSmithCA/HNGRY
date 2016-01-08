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
			var users = this._appRepository.GetUsers();
			if (!this._appRepository.GetFeedEntries().Any() && users.Count >= 2)
			{
				await this._appRepository.AddFoodSubmission(users[0].Id, "10th Floor", "Clam chowder");
				await this._appRepository.AddFoodSubmission(users[1].Id, "11th Floor", "Tomato paste");
				await this._appRepository.AddFoodSubmission(users[0].Id, "91th Floor", "Chopped Panda");
			}
		}
	}
}