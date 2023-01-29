using MicroShop.Catalog.Application.Abstractions.Handlers.Queries;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Catalog.Application.Extensions;
using MicroShop.Catalog.Application.Models;

namespace MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : PaginationQueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(IPaginationQueryServicesContainer paginationQueryServicesContainer)
        : base(paginationQueryServicesContainer) { }

    public override async Task<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await DbContext.Set<Product>()
            .OrderBy(x => x.ProductName)
            .ToPagedListAsync(PaginationService.CurrentPage, PaginationService.PageSize);

        return products;
    }
}