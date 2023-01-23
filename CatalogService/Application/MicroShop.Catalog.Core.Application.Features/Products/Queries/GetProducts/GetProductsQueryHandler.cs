﻿using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Extensions;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Core.Application.Models;
using MicroShop.Catalog.Core.Application.Abstractions.Handlers.Queries;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler : PaginationQueryHandlerBase<GetProductsQuery, PagedList<Product>>
{
    public GetProductsQueryHandler(IPaginationQueryServicesContainer paginationQueryServicesContainer) 
        : base(paginationQueryServicesContainer) { }

    public override async ValueTask<PagedList<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await DbContext.Set<Product>()
            .OrderBy(x => x.ProductName)
            .ToPagedListAsync(PaginationService.CurrentPage, PaginationService.PageSize);

        return products;
    }
}