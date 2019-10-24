using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Entities;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Core.Services;
using NewsFeed.Web.Extensions;
using NewsFeed.Web.Services;
using NewsFeed.Web.ViewModels.Feeds;
using NewsFeed.Web.ViewModels.My;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Presentation.Controllers
{
    public class MyController : Controller
    {
        private readonly FeedService feedService;
        private readonly IFeedsRepository feedRepository;
        private readonly ISubscribersRepository subscribersRepository;
        private readonly IdentityService identityService;
        private readonly IConfigurationProvider configurationProvider;

        public MyController(FeedService feedService, IFeedsRepository feedRepository, ISubscribersRepository subscribersRepository, IdentityService identityService, IConfigurationProvider configurationProvider)
        {
            this.feedService = feedService;
            this.feedRepository = feedRepository;
            this.subscribersRepository = subscribersRepository;
            this.identityService = identityService;
            this.configurationProvider = configurationProvider;
        }

        public async Task<IActionResult> Feeds()
        {
            var userId = identityService.GetUserId();
            var model = new MyFeedsViewModel();
            model.Feeds = await subscribersRepository.GetFeeds(userId).ProjectTo<FeedViewModel>(configurationProvider).ToListAsync();
            return View(model);
        }

    }
}
