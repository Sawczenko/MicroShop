using MicroShop.CatalogService.Core.Abstractions.Requests.Requests.Query;
using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.Core.Interfaces.Database;
using MicroShop.Core.Extensions;
using MicroShop.Core.Models;
using MicroShop.CatalogService.Core.Interfaces.Database;

namespace MicroShop.Catalog.Application.Features.Queries.Products.GetProducts;

internal sealed class GetProductsQueryHandler : QueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(IQueryContainer<ICatalogDbContext> paginationQueryServicesContainer)
        : base(paginationQueryServicesContainer) { }

    public override async Task<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        //TODO: Tymczasowo, podłaczyć Paginator
        var products = await DbContext.Set<Product>()
            .OrderBy(x => x.ProductName)
            .ToPagedListAsync(0,100);

        return products;
    }
}