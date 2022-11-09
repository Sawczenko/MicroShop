using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Database.Entities.Products;

namespace MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;

public sealed class GetProductsQuery : IQueryRequest<ICollection<Product>> { }