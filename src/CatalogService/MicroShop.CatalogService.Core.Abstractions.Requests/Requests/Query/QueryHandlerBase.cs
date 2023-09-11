using MicroShop.Core.Interfaces.Containers.Requests.Query;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.Core.Abstractions.Requests.Query;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.CatalogService.Core.Abstractions.Requests.Requests.Query
{
    public abstract class QueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, ICatalogDbContext, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected QueryHandlerBase(IQueryContainer<ICatalogDbContext> queryContainer)
            : base(queryContainer) { }
    }
}
