using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Data.Context;
using NewsFeed.Web.Identity;
using System;

namespace NewsFeed.Web.Helpers
{
    public static class MigrateDatabases
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FeedContext(serviceProvider.GetRequiredService<DbContextOptions<FeedContext>>()))
            {
                context.Database.Migrate();
            }
            using (var context = new AplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<AplicationDbContext>>()))
            {
                context.Database.Migrate();
            }
        }
    }
}
