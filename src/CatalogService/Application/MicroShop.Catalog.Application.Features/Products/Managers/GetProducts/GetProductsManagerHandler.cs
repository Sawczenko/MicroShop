using MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;
using MicroShop.Core.Abstractions.RequestHandlers.Managers;
using MicroShop.Catalog.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Models;

namespace MicroShop.Catalog.Application.Features.Products.Managers.GetProducts
{
    internal class GetProductsManagerHandler : ManagerHandlerBase<GetProductsManager, PagedList<ProductDto>>
    {
        public GetProductsManagerHandler(IManagerServicesContainer managerServicesContainer)
            : base(managerServicesContainer) { }

        public override async Task<PagedList<ProductDto>> Handle(GetProductsManager request, CancellationToken cancellationToken)
        {
            var products = await ManagerServicesContainer.Mediator.Send(new GetProductsQuery(), cancellationToken);

            return ManagerServicesContainer.MapperService.Map<PagedList<ProductDto>>(products);
        }
    }
}
