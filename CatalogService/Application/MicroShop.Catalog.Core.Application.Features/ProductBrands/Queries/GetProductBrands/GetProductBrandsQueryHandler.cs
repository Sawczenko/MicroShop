using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Database.Entities.ProductBrands;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Core.Application.Features.ProductBrands.Queries.GetProductBrands
{
    internal sealed class GetProductBrandsQueryHandler : QueryHandlerBase<GetProductBrandsQuery, ICollection<ProductBrand>>
    {
        public GetProductBrandsQueryHandler(IQueryServicesContainer queryServicesContainer) 
            : base(queryServicesContainer) { }

        public override async ValueTask<ICollection<ProductBrand>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
        {
            var productBrands = await DbContext.Set<ProductBrand>()
                .ToListAsync(cancellationToken);

            return productBrands;
        }
    }
}
