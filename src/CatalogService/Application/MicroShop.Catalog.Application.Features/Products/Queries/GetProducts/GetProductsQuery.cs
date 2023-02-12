using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Core.Interfaces.Requests.Queries;
using MicroShop.Core.Models;

namespace MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IPaginationQuery<PagedList<Product>> { }