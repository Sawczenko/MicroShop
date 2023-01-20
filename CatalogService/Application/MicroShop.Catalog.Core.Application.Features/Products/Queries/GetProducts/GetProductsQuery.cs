using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Core.Application.Models;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Queries;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IPaginationQuery<PagedList<Product>> { }