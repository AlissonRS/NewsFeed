using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace NewsFeed.Web.Services
{
    public class IdentityService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var claim = httpContextAccessor.HttpContext.User?.Claims?.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            return claim?.Value;
        }
    }
}
