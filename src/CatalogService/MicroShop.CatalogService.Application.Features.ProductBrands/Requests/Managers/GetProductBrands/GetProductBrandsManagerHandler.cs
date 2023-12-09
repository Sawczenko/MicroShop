using MicroShop.Catalog.Application.Features.ProductBrands.Queries.GetProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Managers.GetProductBrands
{
    internal sealed class GetProductBrandsManagerHandler : ManagerHandlerBase<GetProductBrandsManager, IEnumerable<ProductBrand>>
    {
        public GetProductBrandsManagerHandler(IManagerContainer container) 
            : base(container) { }

        public override async Task<RequestResult<IEnumerable<ProductBrand>>> Handle(GetProductBrandsManager request, CancellationToken cancellationToken)
        {
            var productBrands = await Send(new GetProductBrandsQuery(), cancellationToken);

            return RequestResult<IEnumerable<ProductBrand>>.Success(productBrands);
        }
    }
}
