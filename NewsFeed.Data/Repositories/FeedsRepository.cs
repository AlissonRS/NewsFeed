using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Entities;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Data.Repositories
{
    public class FeedsRepository : IFeedsRepository
    {
        private readonly FeedContext feedContext;

        public FeedsRepository(FeedContext feedContext)
        {
            this.feedContext = feedContext;
        }

        public IQueryable<FeedItem> GetAllItems()
        {
            return feedContext.FeedItems.AsQueryable();
        }

        public async Task<Feed> GetFeedById(int feedId)
        {
            return await feedContext.Feeds.Where(f => f.FeedId == feedId).FirstOrDefaultAsync();
        }

        public IQueryable<Feed> GetFeeds()
        {
            return feedContext.Feeds.AsQueryable();
        }

        public IQueryable<FeedItem> GetItems(int feedId)
        {
            return feedContext.FeedItems.Where(i => i.FeedId == feedId).AsQueryable();
        }

        public async Task<int> SaveChanges()
        {
            return await feedContext.SaveChangesAsync();
        }
    }
}
