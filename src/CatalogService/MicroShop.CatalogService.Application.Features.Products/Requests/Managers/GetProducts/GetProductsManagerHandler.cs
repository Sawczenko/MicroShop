using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;
using MicroShop.Core.Models;

namespace MicroShop.CatalogService.Application.Features.Products.Requests.Managers.GetProducts
{
    internal class GetProductsManagerHandler : ManagerHandlerBase<GetProductsManager, PagedList<ProductDto>>
    {
        public GetProductsManagerHandler(IManagerContainer managerServicesContainer)
            : base(managerServicesContainer) { }

        public override async Task<RequestResult<PagedList<ProductDto>>> Handle(GetProductsManager request, CancellationToken cancellationToken)
        {
            var products = await Send(new GetProductsQuery(), cancellationToken);

            var productListDto = await Map<PagedList<ProductDto>>(products);

            return RequestResult<PagedList<ProductDto>>.Success(productListDto); 
        }
    }
}
