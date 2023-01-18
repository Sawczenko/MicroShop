using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Core.Application.Models;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IPaginationQuery<PagedList<Product>> { }