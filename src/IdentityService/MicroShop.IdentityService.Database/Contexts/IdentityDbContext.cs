using MicroShop.IdentityService.Core.Interfaces.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace MicroShop.IdentityService.Database.Contexts
{
    public class IdentityDbContext : IdentityDbContext<MicroShopUser, IdentityRole<int>, int>, IIdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
