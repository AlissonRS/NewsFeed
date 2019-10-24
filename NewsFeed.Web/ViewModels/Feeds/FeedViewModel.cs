using NewsFeed.Core.Entities;

namespace NewsFeed.Web.ViewModels.Feeds
{
    public class FeedViewModel
    {
        public int FeedId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public FeedType FeedType { get; set; }

        public int SubscribersCount { get; set; }

        public bool IsSubscribedTo { get; set; }
    }
}
