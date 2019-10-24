using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Web.Services;
using NewsFeed.Web.ViewModels.Explore;
using NewsFeed.Web.ViewModels.Feeds;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Presentation.Controllers
{
    public class ExploreController : Controller
    {
        private readonly IFeedsRepository feedRepository;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IdentityService identityService;

        public ExploreController(IFeedsRepository feedRepository, IConfigurationProvider configurationProvider, IdentityService identityService)
        {
            this.feedRepository = feedRepository;
            this.configurationProvider = configurationProvider;
            this.identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = identityService.GetUserId();

            var model = new ExploreViewModel();
            model.Feeds = await feedRepository.GetFeeds()
                .Select(f => new FeedViewModel
                {
                    FeedId = f.FeedId,
                    FeedType = f.FeedType,
                    Description = f.Description,
                    Name = f.Name,
                    SubscribersCount = f.Subscribers.Count(),
                    IsSubscribedTo = f.Subscribers.Any(s => s.UserId == userId)
                })
                .ToListAsync();
            return View(model);
        }

    }
}
