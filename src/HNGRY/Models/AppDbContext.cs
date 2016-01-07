using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace HNGRY.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<FeedEntry> FeedEntries { get; set; } 

		public DbSet<QuestionSubmission> QuestionSubmissions { get; set; }

        public DbSet<PostedAnswer> PostedAnswers { get; set; }
    }
}
