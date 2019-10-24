using NewsFeed.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Core.Interfaces.Repositories
{
    public interface IFeedsRepository
    {
        Task<Feed> GetFeedById(int feedId);
        IQueryable<Feed> GetFeeds();
        IQueryable<FeedItem> GetAllItems();
        IQueryable<FeedItem> GetItems(int feedId);
        Task<int> SaveChanges();
    }
}
