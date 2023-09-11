using MicroShop.CatalogService.Core.Containers.Requests.Query;
using MicroShop.Core.Abstractions.Containers.Requests.Manager;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.Core.Abstractions.Containers.Controllers;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.CatalogService.Core.Containers
{
    public static class Registration
    {
        public static void AddContainers(this IServiceCollection services)
        {
            services.AddScoped<IManagerContainer, ManagerContainer>();
            services.AddScoped<IQueryContainer<ICatalogDbContext>, QueryContainer>();
            services.AddScoped<IControllerContainer, ControllerContainer>();
        }
    }
}
