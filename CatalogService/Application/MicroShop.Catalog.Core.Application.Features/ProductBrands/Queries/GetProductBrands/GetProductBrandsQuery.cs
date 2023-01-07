using MicroShop.Catalog.Database.Entities.ProductBrands;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Features.ProductBrands.Queries.GetProductBrands
{
    public sealed record GetProductBrandsQuery : IQuery<ICollection<ProductBrand>> { }
}
