using MicroShop.Core.Abstractions.Requests.Query;
using MicroShop.Core.Interfaces.Containers.Query;
using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.CatalogService.Core.Abstractions.Requests
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, IDbContext, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected QueryHandlerBase(IQueryContainer<IDbContext> queryContainer) 
            : base(queryContainer) { }
    }
}
