using MicroShop.Catalog.Application.Features.Queries.Products.GetProducts;
using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Interfaces.Containers.Manager;
using MicroShop.Core.Models;

namespace MicroShop.CatalogService.Application.Features.Products.Requests.Managers.GetProducts
{
    internal class GetProductsManagerHandler : ManagerHandlerBase<GetProductsManager, PagedList<ProductDto>>
    {
        public GetProductsManagerHandler(IManagerContainer managerServicesContainer)
            : base(managerServicesContainer) { }

        public override async Task<PagedList<ProductDto>> Handle(GetProductsManager request, CancellationToken cancellationToken)
        {
            var products = await Send(new GetProductsQuery(), cancellationToken);

            return await Map<PagedList<ProductDto>>(products);
        }
    }
}
