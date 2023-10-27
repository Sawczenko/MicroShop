using MicroShop.IdentityService.Core.Interfaces.Database;
using MicroShop.IdentityService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.IdentityService.Database
{
    public static class Registration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(options =>
            {
                #if DEBUG
                options.UseInMemoryDatabase("CatalogServiceDatabase");
                #else
                options.UseSqlServer(configuration.GetConnectionString("CatalogService"));
                #endif
            });

            services.AddScoped<IDbContext, IdentityDbContext>();
            services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        }
    }
}
