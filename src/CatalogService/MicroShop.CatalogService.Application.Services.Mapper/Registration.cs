using MicroShop.Catalog.Application.Services.Mapper;
using MicroShop.Core.Interfaces.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace MicroShop.Catalog.Application.Services
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
        }

    }
}
