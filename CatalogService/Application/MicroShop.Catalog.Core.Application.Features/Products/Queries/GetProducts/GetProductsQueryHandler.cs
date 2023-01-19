using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Core.Application.Extensions;
using MicroShop.Catalog.Core.Application.Models;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : PaginationQueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(ICatalogDbContext dbContext, IPagination pagination) : base(dbContext, pagination)
    {
    }

    public override async ValueTask<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await DbContext.Set<Product>().ToPagedListAsync(Pagination.CurrentPage, Pagination.PageSize);

        return products;
    }
}