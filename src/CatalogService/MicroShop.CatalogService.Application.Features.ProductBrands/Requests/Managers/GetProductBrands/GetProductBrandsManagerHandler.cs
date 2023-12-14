using MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Queries.GetProductBrands;
using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Managers.GetProductBrands
{
    internal sealed class GetProductBrandsManagerHandler : ManagerHandlerBase<GetProductBrandsManager, IEnumerable<ProductBrandDto>>
    {
        public GetProductBrandsManagerHandler(IManagerContainer container) 
            : base(container) { }

        public override async Task<RequestResult<IEnumerable<ProductBrandDto>>> Handle(GetProductBrandsManager request, CancellationToken cancellationToken)
        {
            var productBrands = await Send(new GetProductBrandsQuery(), cancellationToken);

            var productBrandsDto = await Map<IEnumerable<ProductBrandDto>>(productBrands);

            return RequestResult<IEnumerable<ProductBrandDto>>.Success(productBrandsDto);
        }
    }
}
