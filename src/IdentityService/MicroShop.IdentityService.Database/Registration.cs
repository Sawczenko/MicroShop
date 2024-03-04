using MicroShop.IdentityService.Core.Interfaces.Database;
using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.IdentityService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MicroShop.Core.Interfaces.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.IdentityService.Database
{
    public static class Registration
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<MicroShopUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<IdentityDbContext>(options =>
            {
#if DEBUG
                options.UseInMemoryDatabase("CatalogServiceDatabase");
#else
                options.UseSqlServer(configuration.GetConnectionString("IdentityService"));
#endif

            });

            services.AddScoped<IDbContext, IdentityDbContext>();
            services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        }
    }
}
