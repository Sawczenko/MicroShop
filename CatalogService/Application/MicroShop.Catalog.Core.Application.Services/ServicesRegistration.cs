using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using MicroShop.Catalog.Core.Application.Services.Pagination;
using MicroShop.Catalog.Core.Application.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Core.Application.Services
{
    public static class ServicesRegistration
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddPaginationService();
            services.AddMapper();
        } 

        private static void AddPaginationService(this IServiceCollection services)
        {
            services.AddScoped<IPaginationService, PaginationService>();
        }

        private static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMapperService, MapperService>();
        }

    }
}
