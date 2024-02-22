using MicroShop.CatalogService.Core.Abstractions.Requests.Requests.Query;
using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using MicroShop.Core.Extensions;
using MicroShop.Core.Models;

namespace MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : QueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(IQueryContainer<ICatalogDbContext> paginationQueryServicesContainer)
        : base(paginationQueryServicesContainer)
    { }

    public override async Task<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await DbContext.Set<Product>()
            .Include(x=>x.ProductBrand)
            .Include(x => x.ProductType)
            .OrderBy(x => x.Name)
            .ToPagedListAsync(0,100, cancellationToken);

        return products;
    }
}