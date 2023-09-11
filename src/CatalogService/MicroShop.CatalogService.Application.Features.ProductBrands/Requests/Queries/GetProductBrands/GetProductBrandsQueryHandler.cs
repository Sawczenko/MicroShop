using MicroShop.CatalogService.Core.Abstractions.Requests.Requests.Query;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Containers.Requests.Query;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    internal sealed class GetProductBrandsQueryHandler : QueryHandlerBase<GetProductBrandsQuery, ICollection<ProductBrand>>
    {
        public GetProductBrandsQueryHandler(IQueryContainer<ICatalogDbContext> queryServicesContainer)
            : base(queryServicesContainer) { }

        public override async Task<ICollection<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            return await DbContext.Set<ProductBrand>()
                .ToListAsync(cancellationToken);
        }
    }
}
