using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsFeed.Core.Interfaces.Repositories;
using NewsFeed.Core.Services;
using NewsFeed.Web.Services;
using NewsFeed.Web.ViewModels.Feeds;
using NewsFeed.Web.ViewModels.Items;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Presentation.Controllers
{
    public class ItemsController : Controller
    {
        private readonly FeedService feedService;
        private readonly IFeedsRepository feedRepository;
        private readonly ISubscribersRepository subscribersRepository;
        private readonly IdentityService identityService;
        private readonly IConfigurationProvider configurationProvider;

        public ItemsController(FeedService feedService, IFeedsRepository feedRepository, ISubscribersRepository subscribersRepository, IdentityService identityService, IConfigurationProvider configurationProvider)
        {
            this.feedService = feedService;
            this.feedRepository = feedRepository;
            this.subscribersRepository = subscribersRepository;
            this.identityService = identityService;
            this.configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllFeedItemsViewModel();
            model.Items = await feedRepository
                .GetAllItems()
                .ProjectTo<FeedItemViewModel>(configurationProvider)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> All(AllFeedItemsViewModel model)
        {
            var query = feedRepository.GetAllItems();
            if (!string.IsNullOrWhiteSpace(model.Search))
            {
                query = query.Where(i =>
                i.Name.Contains(model.Search) ||
                i.Description.Contains(model.Search) ||
                i.Feed.Name.Contains(model.Search) ||
                i.Feed.Description.Contains(model.Search));
            }
            model.Items = await query
                .ProjectTo<FeedItemViewModel>(configurationProvider)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();

            return View(model);
        }

    }
}
