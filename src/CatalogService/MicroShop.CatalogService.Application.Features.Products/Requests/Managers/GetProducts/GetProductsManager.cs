using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Models;

namespace MicroShop.CatalogService.Application.Features.Products.Requests.Managers.GetProducts
{
    public sealed record GetProductsManager : IManager<PagedListDto<ProductDto>> { }
}
