using NewsFeed.Core.Entities;
using NewsFeed.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace NewsFeed.Core.Services
{
    public class FeedService
    {
        private readonly IFeedsRepository feedRepository;

        public FeedService(IFeedsRepository feedRepository)
        {
            this.feedRepository = feedRepository;
        }

        public void SubscribeTo(Feed feed, Subscriber subscriber)
        {
            if (feed.Subscribers.Contains(subscriber))
                return;
            feed.Subscribers.Add(subscriber);
        }

        public async Task<int> SaveChanges()
        {
            return await feedRepository.SaveChanges();
        }

        public void UnsubscribeFrom(Feed feed, Subscriber subscriber)
        {
            if (feed.Subscribers.Contains(subscriber))
                feed.Subscribers.Remove(subscriber);
        }
    }
}

