using Microsoft.AspNetCore.Mvc;
using NewsFeed.Web.ViewModels.Shared;
using Newtonsoft.Json;

namespace NewsFeed.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddFrontendMessage(this Controller controller, MessageStatus status, string message)
        {
            controller.TempData["FrontendMessage"] = JsonConvert.SerializeObject(new FrontendMessage(status, message));
        }
    }
}
