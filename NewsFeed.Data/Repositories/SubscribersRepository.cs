using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Entities;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Data.Repositories
{
    public class SubscribersRepository : ISubscribersRepository
    {
        private readonly FeedContext feedContext;

        public SubscribersRepository(FeedContext feedContext)
        {
            this.feedContext = feedContext;
        }

        public IQueryable<Feed> GetFeeds(string userId)
        {
            return feedContext.Feeds.Where(f => f.Subscribers.Any(s => s.UserId == userId)).AsQueryable();
        }

        public async Task<Subscriber> GetSubscriberByUserAndFeed(string userId, int feedId)
        {
            return await feedContext.Subscribers.Where(s => s.UserId == userId && s.FeedId == feedId).FirstOrDefaultAsync();
        }
    }
}
