using MicroShop.Core.Abstractions.RequestHandlers.Queries;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Extensions;
using MicroShop.Core.Models;

namespace MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : PaginationQueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(IPaginationQueryServicesContainer paginationQueryServicesContainer)
        : base(paginationQueryServicesContainer) { }

    public override async Task<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await PaginationQueryServicesContainer.DbContext.Set<Product>()
            .OrderBy(x => x.ProductName)
            .ToPagedListAsync(PaginationQueryServicesContainer.PaginationService.CurrentPage, PaginationQueryServicesContainer.PaginationService.PageSize);

        return products;
    }
}