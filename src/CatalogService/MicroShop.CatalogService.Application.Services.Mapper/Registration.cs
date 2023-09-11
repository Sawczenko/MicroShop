using MicroShop.Catalog.Application.Services.Mapper;
using MicroShop.Core.Interfaces.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;
using Mapster;

namespace MicroShop.Catalog.Application.Services
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IMapperService, MapperService>();
        }
    }
}
