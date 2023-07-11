using MicroShop.Catalog.Application.Entities.ProductBrands;
using MicroShop.Core.Abstractions.Requests.Query;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    internal sealed class GetProductBrandsQueryHandler : QueryHandlerBase
    {
        public GetProductBrandsQueryHandler(IQueryServicesContainer queryServicesContainer)
            : base(queryServicesContainer) { }

        public override async Task<ICollection<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            var productBrands = await QueryServicesContainer.DbContext.Set<ProductBrand>()
                .ToListAsync(cancellationToken);

            return productBrands;
        }
    }
}
