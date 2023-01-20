using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using MicroShop.Catalog.Core.Application.Abstractions.Pagination;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Core.Application.Services
{
    public static class ServicesRegistration
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPaginationService, PaginationService>();
        } 

    }
}
