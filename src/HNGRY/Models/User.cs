namespace HNGRY.Models
{
	using Microsoft.AspNet.Identity.EntityFramework;

	public class User : IdentityUser
    {
		public string FullName { get; set; }
    }
}
