using MicroShop.Catalog.Application.Services.Pagination;
using MicroShop.Catalog.Application.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Interfaces.Services;

namespace MicroShop.Catalog.Application.Services
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
