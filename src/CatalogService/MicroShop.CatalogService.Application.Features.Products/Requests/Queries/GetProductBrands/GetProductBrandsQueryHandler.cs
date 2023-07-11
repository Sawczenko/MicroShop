using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Core.Abstractions.Requests;
using MicroShop.Core.Interfaces.Containers.Query;
using MicroShop.Core.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    internal sealed class GetProductBrandsQueryHandler : QueryHandlerBase<GetProductBrandsQuery, ICollection<ProductBrand>>
    {
        public GetProductBrandsQueryHandler(IQueryContainer<IDbContext> queryServicesContainer)
            : base(queryServicesContainer) { }

        public override async Task<ICollection<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            var productBrands = await DbContext.Set<ProductBrand>()
                .ToListAsync(cancellationToken);

            return productBrands;
        }
    }
}
