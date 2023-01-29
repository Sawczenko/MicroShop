using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Queries;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Application.Models;

namespace MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IPaginationQuery<PagedList<Product>> { }