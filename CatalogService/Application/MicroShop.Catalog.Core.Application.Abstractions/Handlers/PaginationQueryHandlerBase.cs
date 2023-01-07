using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers
{
    public abstract class PaginationQueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IPaginationQuery<TResponse>
    {
        public PaginationQueryHandlerBase(ICatalogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
