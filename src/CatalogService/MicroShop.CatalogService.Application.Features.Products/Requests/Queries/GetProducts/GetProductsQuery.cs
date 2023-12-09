using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Models;

namespace MicroShop.Catalog.Application.Features.Queries.Products.GetProducts;

internal sealed record GetProductsQuery : IQuery<PagedList<Product>> { }