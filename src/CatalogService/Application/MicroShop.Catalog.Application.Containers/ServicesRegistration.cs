using MicroShop.Catalog.Application.Containers.Containers;
using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Interfaces.Containers.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Application.Containers
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
