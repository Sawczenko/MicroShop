using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

public sealed class GetProductsQueryHandler : QueryHandlerBase<GetProductsQuery, ICollection<Product>, ICatalogDbContext>
{
    public GetProductsQueryHandler(ICatalogDbContext dbContext) 
        : base(dbContext) { }


    public override async ValueTask<ICollection<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Product>().ToListAsync(cancellationToken);
    }
}