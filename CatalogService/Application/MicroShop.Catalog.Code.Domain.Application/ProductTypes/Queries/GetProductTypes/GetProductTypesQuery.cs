using MicroShop.Catalog.Database.Entities.ProductTypes;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Features.ProductTypes.Queries.GetProductTypes
{
    public sealed record GetProductTypesQuery : IQuery<ICollection<ProductType>> { }
}
