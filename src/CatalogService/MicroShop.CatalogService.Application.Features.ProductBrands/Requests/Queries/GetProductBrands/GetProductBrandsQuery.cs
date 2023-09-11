using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    public sealed record GetProductBrandsQuery : IQuery<ICollection<ProductBrand>> { }
}
