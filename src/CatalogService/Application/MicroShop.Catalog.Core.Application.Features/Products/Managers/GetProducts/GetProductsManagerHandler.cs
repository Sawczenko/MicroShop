using MicroShop.Catalog.Application.Features.Products.Queries.GetProducts;
using MicroShop.Catalog.Application.Abstractions.Handlers.Managers;
using MicroShop.Catalog.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Catalog.Application.Models;

namespace MicroShop.Catalog.Application.Features.Products.Managers.GetProducts
{
    internal class GetProductsManagerHandler : ManagerHandlerBase<GetProductsManager, PagedList<ProductDto>>
    {
        public GetProductsManagerHandler(IManagerServicesContainer managerServicesContainer)
            : base(managerServicesContainer) { }

        public override async Task<PagedList<ProductDto>> Handle(GetProductsManager request, CancellationToken cancellationToken)
        {
            var products = await Mediator.Send(new GetProductsQuery(), cancellationToken);

            return MapperService.Map<PagedList<ProductDto>>(products);
        }
    }
}
