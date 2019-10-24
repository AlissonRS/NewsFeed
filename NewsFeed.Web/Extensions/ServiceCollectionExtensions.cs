using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Core.Services;
using NewsFeed.Data.Repositories;
using NewsFeed.Web.Services;

namespace NewsFeed.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped<IFeedsRepository, FeedsRepository>();
            services.AddScoped<ISubscribersRepository, SubscribersRepository>();

            // Services
            services.AddScoped<FeedService>();
            services.AddScoped<IdentityService>();

            return services;
        }
    }
}
