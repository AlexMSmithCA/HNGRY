namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;
	using System.Linq;
	using HNGRY.Services;

	public class SeedPostedAnswers
	{
		private readonly IAppDbRepository _appRepository;

		public SeedPostedAnswers(IAppDbRepository appRepository)
		{
			this._appRepository = appRepository;
		}

		public async Task InsertPostedAnswers()
		{
			var users = this._appRepository.GetUsers();
			if (!this._appRepository.GetPostedAnswers().Any() && users.Count >= 2)
			{
				await this._appRepository.AddPostedAnswer(users[1].Id, "Sadly, no Dunkaroos", "Dale Fox", "A lot of folks have been requesting dunkaroos these days. Unfortunately in order to ship them to the USA we would be violating some NAFTA international foreign trade agreements. We'll have to make due with the other 100 snacks in the office.");
				await this._appRepository.AddPostedAnswer(users[0].Id, "New trail mix!", "Bonnie Louis", "We're trying out a new brand of trail mix, let us know what you think!");
			}
		}
	}
}