using MicroShop.CatalogService.Core.Abstractions.Requests;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.Core.Abstractions.Requests.Query;
using MicroShop.Core.Interfaces.Containers.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Catalog.Application.Features.Queries.ProductTypes.GetProductTypes
{
    internal sealed class GetProductTypesQueryHandler : QueryHandlerBase<GetProductTypesQuery, ICollection<ProductType>>
    {
        public GetProductTypesQueryHandler(IQueryContainer<IDbContext> queryServicesContainer)
            : base(queryServicesContainer) { }

        public override Task<ICollection<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
