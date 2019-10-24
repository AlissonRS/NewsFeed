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
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Presentation.Controllers
{
    public class FeedsController : Controller
    {
        private readonly FeedService feedService;
        private readonly IFeedsRepository feedRepository;
        private readonly ISubscribersRepository subscribersRepository;
        private readonly IdentityService identityService;
        private readonly IConfigurationProvider configurationProvider;

        public FeedsController(FeedService feedService, IFeedsRepository feedRepository, ISubscribersRepository subscribersRepository, IdentityService identityService, IConfigurationProvider configurationProvider)
        {
            this.feedService = feedService;
            this.feedRepository = feedRepository;
            this.subscribersRepository = subscribersRepository;
            this.identityService = identityService;
            this.configurationProvider = configurationProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Items(int feedId)
        {
            var feed = await feedRepository.GetFeedById(feedId);
            if (feed == null)
            {
                this.AddFrontendMessage(Web.ViewModels.Shared.MessageStatus.Danger, "Feed not found");
                return RedirectToAction("Index", "Explore");
            }
            var model = new FeedItemsViewModel();
            model.FeedId = feedId;
            model.FeedName = feed.Name;
            model.Items = await feedRepository
                .GetItems(feedId)
                .ProjectTo<FeedItemViewModel>(configurationProvider)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Items(int feedId, FeedItemsViewModel model)
        {
            var query = feedRepository.GetItems(feedId);
            if (!string.IsNullOrWhiteSpace(model.Search))
            {
                query = query.Where(i =>
                i.Name.Contains(model.Search) ||
                i.Description.Contains(model.Search));
            }
            model.Items = await query
                .ProjectTo<FeedItemViewModel>(configurationProvider)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribe(int feedId)
        {
            var feed = await feedRepository.GetFeedById(feedId);
            if (feed == null)
            {
                this.AddFrontendMessage(Web.ViewModels.Shared.MessageStatus.Danger, "Feed not found");
                return RedirectToAction("Index", "Explore");
            }
            var userId = identityService.GetUserId();
            var subscriber = await subscribersRepository.GetSubscriberByUserAndFeed(userId, feedId);
            if (subscriber == null)
            {
                feedService.SubscribeTo(feed, new Subscriber(userId));
                await feedService.SaveChanges();
            }
            return RedirectToAction("Items", new { feedId });
        }

        [HttpGet]
        public async Task<IActionResult> Unsubscribe(int feedId, string returnUrl)
        {
            var feed = await feedRepository.GetFeedById(feedId);
            if (feed == null)
            {
                this.AddFrontendMessage(Web.ViewModels.Shared.MessageStatus.Danger, "Feed not found");
                return RedirectToAction("Index", "Explore");
            }
            var userId = identityService.GetUserId();
            var subscriber = await subscribersRepository.GetSubscriberByUserAndFeed(userId, feedId);
            if (subscriber != null)
            {
                feedService.UnsubscribeFrom(feed, subscriber);
                await feedService.SaveChanges();
            }
            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Explore");
            return Redirect(returnUrl);
        }

    }
}
