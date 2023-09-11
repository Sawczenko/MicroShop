using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Requests.Manager;

namespace MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Managers.GetProductTypes
{
    public sealed record GetProductTypesManager : IManager<IEnumerable<ProductTypeDto>>
    {
    }
}
