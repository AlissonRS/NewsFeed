using AutoMapper;
using NewsFeed.Core.Entities;
using NewsFeed.Web.ViewModels.Feeds;
using System.Linq;

namespace NewsFeed.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        private readonly string userId;
        
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Feed, FeedViewModel>()
                .ForMember(m => m.SubscribersCount, opt => opt.MapFrom(e => e.Subscribers.Count()))
                .ForMember(m => m.IsSubscribedTo, opt => opt.Ignore())
                ;

            CreateMap<FeedItem, FeedItemViewModel>()
                .ForMember(m => m.FeedName, opt => opt.MapFrom(e => e.Feed.Name))
                ;
        }
    }
}
