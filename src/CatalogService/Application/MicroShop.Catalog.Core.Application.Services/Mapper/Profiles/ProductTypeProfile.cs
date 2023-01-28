using MicroShop.Catalog.Application.DataTransferObjects;
using MicroShop.Catalog.Database.Entities.ProductTypes;
using AutoMapper;

namespace MicroShop.Catalog.Application.Services.Mapper.Profiles
{
    internal class ProductTypeProfile : Profile
    {

        public ProductTypeProfile()
        {
            CreateMap<ProductTypeDto, ProductType>().ReverseMap();
        }

    }
}
