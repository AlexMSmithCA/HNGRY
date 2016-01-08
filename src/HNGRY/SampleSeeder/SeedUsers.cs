namespace HNGRY.SampleSeeder
{
	using System.Threading.Tasks;
	using System.Linq;
	using HNGRY.Services;
	using HNGRY.Models;
	using Microsoft.AspNet.Identity;

	public class SeedUsers
	{
		private readonly IAppDbRepository _appRepository;
		private readonly UserManager<User> _userManager;

		public SeedUsers(
			IAppDbRepository appRepository,
			UserManager<User> userManager)
		{
			this._appRepository = appRepository;
			this._userManager = userManager;
		}

		public async Task InsertUsers()
		{
			if (!this._appRepository.GetUsers().Any())
			{
				var userHunGarry = new User { UserName = @"ATP\HunGarry", FullName = "Hun Garry" };
				var userLuvFude = new User { UserName = @"ATP\LuvFude", FullName = "Luv Fude" };
				await this._userManager.CreateAsync(userHunGarry, "Asdf12#456");
				await this._userManager.CreateAsync(userLuvFude, "Asdf12#456");
			}
		}
	}
}