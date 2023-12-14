using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Queries.GetProductBrands
{
    internal sealed record GetProductBrandsQuery : IQuery<ICollection<ProductBrand>> { }
}
