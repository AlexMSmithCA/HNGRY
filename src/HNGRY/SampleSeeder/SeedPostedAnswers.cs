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
				await this._appRepository.AddPostedAnswer(users[1].Id, "No Dunkaroos", "Dale Faux", "Seriously, no more Dunkaroos.  Those are so 1988.");
				await this._appRepository.AddPostedAnswer(users[0].Id, "Really no dunkaroos", "Bonnie Louis", "Bon voyage to all of Sean Walsh's requests for carrots since he has decided to bring his own.");
			}
		}
	}
}