using System;

namespace NewsFeed.Core.Entities
{
    public class Subscriber
    {
        public string SubscriberId { get; protected set; }

        public string UserId { get; protected set; }

        public int FeedId { get; protected set; }

        protected Subscriber()
        {
            // protected ctor for EF proxies
            SubscriberId = Guid.NewGuid().ToString();
        }

        public Subscriber(string userId) : this()
        {
            this.UserId = userId;
        }
    }
}