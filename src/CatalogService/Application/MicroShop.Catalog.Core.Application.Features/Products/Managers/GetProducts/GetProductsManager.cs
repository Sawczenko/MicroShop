using MicroShop.Catalog.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Requests.Managers;
using MicroShop.Catalog.Application.Models;

namespace MicroShop.Catalog.Application.Features.Products.Managers.GetProducts
{
    public sealed record GetProductsManager : IManager<PagedList<ProductDto>> { }
}
