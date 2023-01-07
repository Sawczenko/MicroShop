using MicroShop.Catalog.Core.Application.Abstractions.Handlers;
using MicroShop.Catalog.Database.Entities.ProductTypes;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Features.ProductTypes.Queries.GetProductTypes
{
    internal sealed class GetProductTypesQueryHandler : QueryHandlerBase<GetProductTypesQuery, ICollection<ProductType>>
    {
        public GetProductTypesQueryHandler(ICatalogDbContext dbContext) 
            : base(dbContext) { }

        public override ValueTask<ICollection<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
