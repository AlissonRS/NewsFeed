using System.Collections.Generic;

namespace NewsFeed.Core.Entities
{
    public class Feed
    {
        public int FeedId { get; set; }

        public FeedType FeedType { get; set; }

        public ICollection<FeedItem> Items { get; set; }

        public ICollection<Subscriber> Subscribers { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Feed()
        {
            this.Subscribers = new HashSet<Subscriber>();
            this.Items = new HashSet<FeedItem>();
        }

    }
}
