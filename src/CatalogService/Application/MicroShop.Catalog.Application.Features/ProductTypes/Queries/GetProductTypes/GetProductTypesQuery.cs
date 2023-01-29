using MicroShop.Catalog.Database.Entities.ProductTypes;
using MicroShop.Core.Interfaces.Requests.Queries;

namespace MicroShop.Catalog.Application.Features.ProductTypes.Queries.GetProductTypes
{
    public sealed record GetProductTypesQuery : IQuery<ICollection<ProductType>> { }
}
