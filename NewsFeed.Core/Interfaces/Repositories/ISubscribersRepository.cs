using NewsFeed.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Core.Interfaces.Repositories
{
    public interface ISubscribersRepository
    {
        Task<Subscriber> GetSubscriberByUserAndFeed(string userId, int feedId);
        IQueryable<Feed> GetFeeds(string userId);
    }
}