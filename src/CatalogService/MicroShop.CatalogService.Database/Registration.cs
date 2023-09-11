using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Database.Contexts;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Interfaces.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

public static class Registration
{
    public static void AddCatalogDatabase(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddDbContext<CatalogDbContext>(options =>
        {
            #if DEBUG
                options.UseInMemoryDatabase("CatalogServiceDatabase");
#else
                options.UseSqlServer(configuration.GetConnectionString("CatalogService"));
#endif          
        });
        services.AddScoped<ICatalogDbContext, CatalogDbContext>();
    }

    public static void SeedDatabase(this IApplicationBuilder applicationBuilder) 
    {
        using (var scope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ICatalogDbContext>();

            context.Database.EnsureCreated();
        }
        
    }
}