using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Models;

namespace MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;

internal sealed record GetProductsQuery : IQuery<PagedList<Product>> { }