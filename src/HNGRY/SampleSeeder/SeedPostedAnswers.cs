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
			if (!this._appRepository.GetPostedAnswers().Any())
			{
				//await this._appRepository.AddPostedAnswer("No Dunkaroos", "Dale Faux", "Seriously, no more Dunkaroos.  Those are so 1988.");
				//await this._appRepository.AddPostedAnswer("Really no dunkaroos","Bonnie Louis", "Bon voyage to all of Sean Walsh's requests for carrots since he has decided to bring his own.");
			}
		}
	}
}