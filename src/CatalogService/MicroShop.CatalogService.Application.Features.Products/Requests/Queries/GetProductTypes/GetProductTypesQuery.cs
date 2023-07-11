using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.Catalog.Application.Features.Queries.ProductTypes.GetProductTypes
{
    public sealed record GetProductTypesQuery : IQuery<ICollection<ProductType>> { }
}
