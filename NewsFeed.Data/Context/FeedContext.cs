using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Entities;

namespace NewsFeed.Data.Context
{
    public class FeedContext: DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public FeedContext(DbContextOptions<FeedContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.DataSeed(modelBuilder);
        }

    }
}
