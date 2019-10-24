using System.Collections.Generic;

namespace NewsFeed.Web.ViewModels.Feeds
{
    public class FeedItemsViewModel
    {
        public List<FeedItemViewModel> Items { get; set; }

        public int FeedId { get; set; }

        public string FeedName { get; set; }

        public string Search { get; set; }
    }
}
