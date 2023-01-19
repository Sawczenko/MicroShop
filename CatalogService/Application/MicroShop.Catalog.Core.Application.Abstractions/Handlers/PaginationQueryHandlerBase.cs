using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Database.Interfaces;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers
{
    public abstract class PaginationQueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public IPagination Pagination { get; set; }


        protected PaginationQueryHandlerBase(ICatalogDbContext dbContext, IPagination pagination) : base(dbContext)
        {
            Pagination = pagination;
        }
    }
}
