using MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Queries.GetProductTypes;
using MicroShop.CatalogService.Core.Abstractions.Requests.Requests.Query;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.Core.Interfaces.Containers.Requests.Query;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Application.Features.Queries.ProductTypes.GetProductTypes
{
    internal sealed class GetProductTypesQueryHandler : QueryHandlerBase<GetProductTypesQuery, ICollection<ProductType>>
    {
        public GetProductTypesQueryHandler(IQueryContainer<ICatalogDbContext> queryServicesContainer)
            : base(queryServicesContainer) { }

        public override async Task<ICollection<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await DbContext.Set<ProductType>().ToListAsync(cancellationToken);
        }
    }
}
