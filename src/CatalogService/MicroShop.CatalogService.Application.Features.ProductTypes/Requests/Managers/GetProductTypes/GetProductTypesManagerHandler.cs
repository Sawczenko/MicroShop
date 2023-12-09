using MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Queries.GetProductTypes;
using MicroShop.CatalogService.Application.DataTransferObjects;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Managers.GetProductTypes
{
    internal sealed class GetProductTypesManagerHandler : ManagerHandlerBase<GetProductTypesManager, IEnumerable<ProductTypeDto>>
    {
        public GetProductTypesManagerHandler(IManagerContainer container) 
            : base(container) { }

        public override async Task<RequestResult<IEnumerable<ProductTypeDto>>> Handle(GetProductTypesManager request, CancellationToken cancellationToken)
        {
            var productTypes = await Send(new GetProductTypesQuery(), cancellationToken);

            var productTypeDtos = await Map<IEnumerable<ProductTypeDto>>(productTypes);

            return RequestResult<IEnumerable<ProductTypeDto>>.Success(productTypeDtos);
        }
    }
}
