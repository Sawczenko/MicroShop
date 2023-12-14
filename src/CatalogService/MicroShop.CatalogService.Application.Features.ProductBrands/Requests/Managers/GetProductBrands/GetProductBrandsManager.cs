using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Requests.Manager;

namespace MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Managers.GetProductBrands
{
    public sealed record GetProductBrandsManager : IManager<IEnumerable<ProductBrandDto>>
    {
    }
}
