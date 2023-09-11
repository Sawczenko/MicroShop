using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Queries.GetProductTypes
{
    public sealed record GetProductTypesQuery : IQuery<ICollection<ProductType>> { }
}
