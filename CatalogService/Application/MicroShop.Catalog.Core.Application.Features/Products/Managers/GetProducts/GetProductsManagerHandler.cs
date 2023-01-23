using MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Handlers.Managers;
using MicroShop.Catalog.Core.Application.DataTransferObjects;
using MicroShop.Catalog.Core.Application.Models;

namespace MicroShop.Catalog.Core.Application.Features.Products.Managers.GetProducts
{
    internal class GetProductsManagerHandler : ManagerHandlerBase<GetProductsManager, PagedList<ProductDto>>
    {
        public GetProductsManagerHandler(IManagerServicesContainer managerServicesContainer) 
            : base(managerServicesContainer) { }

        public override async ValueTask<PagedList<ProductDto>> Handle(GetProductsManager request, CancellationToken cancellationToken)
        {
            var products = await Mediator.Send(new GetProductsQuery(), cancellationToken);

            return MapperService.Map<PagedList<ProductDto>>(products);
        }
    }
}
