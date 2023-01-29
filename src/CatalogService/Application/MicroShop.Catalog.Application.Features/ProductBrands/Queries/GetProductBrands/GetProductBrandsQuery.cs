using MicroShop.Catalog.Database.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Requests.Queries;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    public sealed record GetProductBrandsQuery : IQuery<ICollection<ProductBrand>> { }
}
