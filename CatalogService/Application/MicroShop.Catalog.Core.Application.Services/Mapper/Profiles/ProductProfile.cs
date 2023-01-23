using MicroShop.Catalog.Core.Application.Services.Mapper.Converters;
using MicroShop.Catalog.Core.Application.DataTransferObjects;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Core.Application.Models;
using AutoMapper;

namespace MicroShop.Catalog.Core.Application.Services.Mapper.Profiles
{
    internal class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<PagedList<Product>, PagedList<ProductDto>>().ConvertUsing(typeof(PagedListConverter<Product, ProductDto>));
        }

    }
}
