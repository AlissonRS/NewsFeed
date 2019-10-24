using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Entities;
using System;

namespace NewsFeed.Data.Context
{
    public static class SeedData
    {
        private readonly static Random _random = new Random(47);

        public static ModelBuilder DataSeed(this ModelBuilder modelBuilder)
        {
            // random data for testing :)
            int feedItemId = 0;
            for (int i = 1; i < 17; i++)
            {
                modelBuilder.Entity<Feed>().HasData(new Feed { FeedId = i, FeedType = FeedType.News, Name = $"Feed {i}", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." });

                for (int j = 1; j < 17; j++)
                {
                    feedItemId++;
                    var comments = _random.Next(0, 999);
                    var likes = _random.Next(0, 999);
                    modelBuilder.Entity<FeedItem>().HasData(new FeedItem {
                        FeedItemId = feedItemId,
                        FeedId = i,
                        Name = $"Article {feedItemId}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        CommentsCount = comments,
                        LikesCount = likes,
                        CreatedAt = RandomDay()
                    });
                }
            }
            
            return modelBuilder;
        }

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(2011, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }
    }
}
