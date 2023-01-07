using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : PaginationQueryHandlerBase<GetProductsQuery, ICollection<Product>>
{
    public GetProductsQueryHandler(ICatalogDbContext dbContext) 
        : base(dbContext) { }

    public override async ValueTask<ICollection<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await DbContext.Set<Product>().Skip(query.Pagination.PageSize).ToListAsync(cancellationToken);

        return products;
    }
}