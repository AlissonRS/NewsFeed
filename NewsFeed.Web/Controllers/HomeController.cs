using Microsoft.AspNetCore.Mvc;

namespace NewsFeed.Presentation.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }

}
