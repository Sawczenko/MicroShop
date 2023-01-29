using MicroShop.Catalog.Application.Services.Mapper.Converters;
using MicroShop.Catalog.Application.DataTransferObjects;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Application.Models;
using AutoMapper;

namespace MicroShop.Catalog.Application.Services.Mapper.Profiles
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
