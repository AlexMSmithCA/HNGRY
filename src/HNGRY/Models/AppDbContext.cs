namespace HNGRY.Models
{
	using Microsoft.Data.Entity;

	public class AppDbContext : DbContext
    {
	    public AppDbContext()
	    {
		    this.Database.EnsureCreated();
	    }

        public DbSet<FeedEntry> FeedEntries { get; set; } 

		public DbSet<QuestionSubmission> QuestionSubmissions { get; set; }

        public DbSet<PostedAnswer> PostedAnswers { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
