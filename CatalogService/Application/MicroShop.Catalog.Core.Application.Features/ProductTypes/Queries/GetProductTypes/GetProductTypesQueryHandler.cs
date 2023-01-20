using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Database.Entities.ProductTypes;

namespace MicroShop.Catalog.Core.Application.Features.ProductTypes.Queries.GetProductTypes
{
    internal sealed class GetProductTypesQueryHandler : QueryHandlerBase<GetProductTypesQuery, ICollection<ProductType>>
    {
        public GetProductTypesQueryHandler(IQueryServicesContainer queryServicesContainer) 
            : base(queryServicesContainer) { }

        public override ValueTask<ICollection<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
