using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Containers.Containers;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Core.Application.Containers
{
    public static class ServicesRegistration
    {

        public static void AddContainers(this IServiceCollection services)
        {
            services.AddScoped<IQueryServicesContainer, QueryServicesContainer>();
            services.AddScoped<IPaginationQueryServicesContainer, PaginationQueryServicesContainer>();
            services.AddScoped<IManagerServicesContainer, ManagerServicesContainer>();
        }

    }
}
