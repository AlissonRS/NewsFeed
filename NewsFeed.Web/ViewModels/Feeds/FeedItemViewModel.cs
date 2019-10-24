using System;

namespace NewsFeed.Web.ViewModels.Feeds
{
    public class FeedItemViewModel
    {
        public int FeedItemId { get; set; }

        public int FeedId { get; set; }

        public string FeedName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}