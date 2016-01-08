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
				await this._appRepository.AddFoodSubmission(users[0].Id, "10th Floor", "Uncle Julios is here!");
				await this._appRepository.AddFoodSubmission(users[1].Id, "11th Floor", "Leftover chips and guac, #snackathon");
				await this._appRepository.AddFoodSubmission(users[0].Id, "10th Floor", "Pizza on 10, the veggie is so good :)");
                await this._appRepository.AddFoodSubmission(users[1].Id, "10th Floor", "Omma'let you all know there's omlettes on 10, enjoy!");
                await this._appRepository.AddFoodSubmission(users[0].Id, "9th Floor", "Try my homemade Chobani, because there's never enough in the fridge.");
            }
		}
	}
}