using MicroShop.Core.Abstractions.RequestHandlers.Queries;
using MicroShop.Catalog.Database.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Containers.Queries;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands
{
    internal sealed class GetProductBrandsQueryHandler : QueryHandlerBase<GetProductBrandsQuery, ICollection<ProductBrand>>
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
