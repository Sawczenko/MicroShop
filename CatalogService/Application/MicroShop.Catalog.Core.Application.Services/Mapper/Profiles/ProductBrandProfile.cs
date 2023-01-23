using MicroShop.Catalog.Core.Application.DataTransferObjects;
using MicroShop.Catalog.Database.Entities.ProductBrands;
using AutoMapper;

namespace MicroShop.Catalog.Core.Application.Services.Mapper.Profiles
{
    internal class ProductBrandProfile : Profile
    {

        public ProductBrandProfile()
        {
            CreateMap<ProductBrandDto, ProductBrand>().ReverseMap();
        }

    }
}
