using MicroShop.Core.Abstractions.RequestHandlers.Queries;
using MicroShop.Catalog.Database.Entities.ProductTypes;
using MicroShop.Core.Interfaces.Containers.Queries;

namespace MicroShop.Catalog.Application.Features.ProductTypes.Queries.GetProductTypes
{
    internal sealed class GetProductTypesQueryHandler : QueryHandlerBase<GetProductTypesQuery, ICollection<ProductType>>
    {
        public GetProductTypesQueryHandler(IQueryServicesContainer queryServicesContainer)
            : base(queryServicesContainer) { }

        public override Task<ICollection<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
