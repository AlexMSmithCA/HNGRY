namespace HNGRY.Attributes
{
	using System;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using HNGRY.Models;
	using HNGRY.Services;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Mvc.Filters;
	using Microsoft.AspNet.Mvc;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class AutoLoginAttribute : ActionFilterAttribute
	{
		private static object _autoLoginLock = new Object();

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var userManager = (UserManager<User>)context.HttpContext.ApplicationServices.GetService(typeof (UserManager<User>));
			var signInManager = (SignInManager<User>)context.HttpContext.ApplicationServices.GetService(typeof(SignInManager<User>));
			var appRepository = (IAppDbRepository)context.HttpContext.ApplicationServices.GetService(typeof(IAppDbRepository));

			lock (_autoLoginLock)
			{
				var userContext = context?.HttpContext.User;
				var userInfo = new
				{
					IsSignedIn = userContext?.IsSignedIn() == true,
					IsAuthenticated = userContext?.Identity.IsAuthenticated == true,
					Username = userContext?.GetUserName()
				};
				if (userInfo.Username == null || !userInfo.IsAuthenticated)
				{
					// Cannot authenticate this user!
					context.Result = new RedirectToRouteResult("Navigation", "Error");
				}

				if (!userInfo.IsSignedIn && userInfo.IsAuthenticated)
				{
					// Sign in the user, and let them continue on their way
					// We'll want to sign in the user here!
					var user = appRepository.GetUserFromName(userContext.GetUserName());

					var allUsers = appRepository.GetUsers();

					if (user == null || allUsers == null)
					{
						// Create a new user and sign them in
						user = new User { UserName = userContext.GetUserName() };
						Task.WhenAll(userManager.CreateAsync(user, "my_pAsSwOrD123"));
					}

					Task.WhenAll(signInManager.SignInAsync(user, isPersistent: false));
				}
			}

			base.OnActionExecuting(context);
			return;
		}
	}
}
