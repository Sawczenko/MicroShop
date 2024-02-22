using System.Collections;
using System.Reflection;
using MicroShop.Catalog.Application.Services.Mapper;
using MicroShop.Core.Interfaces.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;
using Mapster;
using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroShop.Catalog.Application.Services
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();

            config.Apply(new PagedListMapper());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IMapperService, MapperService>();
        }
    }

    public class PagedListMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PagedList<Product>, PagedList<ProductDto>>()
                .Map(dest => dest.IsFirstPage, src => src.IsFirstPage)
                .Map(dest => dest.IsLastPage, src => src.IsLastPage)
                .Map(dest => dest.Items, src => src.Items.Adapt<List<ProductDto>>())
                .PreserveReference(false);
        }
    }
}
