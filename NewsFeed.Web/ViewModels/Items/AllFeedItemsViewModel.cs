using NewsFeed.Web.ViewModels.Feeds;
using System.Collections.Generic;

namespace NewsFeed.Web.ViewModels.Items
{
    public class AllFeedItemsViewModel
    {
        public List<FeedItemViewModel> Items { get; set; }

        public string Search { get; set; }
    }
}
