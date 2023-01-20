using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.Catalog.Database.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Database;

public static class ServicesRegistration
{
    public static void AddCatalogDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ICatalogDbContext, CatalogDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("CatalogService"))
            );
    }
}