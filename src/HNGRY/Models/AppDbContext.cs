using Microsoft.AspNet.Identity.EntityFramework;

namespace HNGRY.Models
{
	using Microsoft.Data.Entity;

	public class AppDbContext : IdentityDbContext<User>
    {
	    public AppDbContext()
	    {
		    this.Database.EnsureCreated();
	    }

        public DbSet<FeedEntry> FeedEntries { get; set; } 

		public DbSet<QuestionSubmission> QuestionSubmissions { get; set; }

        public DbSet<PostedAnswer> PostedAnswers { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<PostedAnswer> PostedFeedEntries { get; set; }
    }
}
