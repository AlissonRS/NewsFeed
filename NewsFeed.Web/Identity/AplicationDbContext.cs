using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NewsFeed.Web.Identity
{
    public class AplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
