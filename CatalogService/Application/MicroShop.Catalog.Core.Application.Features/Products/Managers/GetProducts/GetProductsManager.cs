using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Managers;
using MicroShop.Catalog.Core.Application.DataTransferObjects;
using MicroShop.Catalog.Core.Application.Models;

namespace MicroShop.Catalog.Core.Application.Features.Products.Managers.GetProducts
{
    public sealed record GetProductsManager : IManager<PagedList<ProductDto>> { }
}
