using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemoApi.Context
{
    public class MyApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
        {
        }
    }
}