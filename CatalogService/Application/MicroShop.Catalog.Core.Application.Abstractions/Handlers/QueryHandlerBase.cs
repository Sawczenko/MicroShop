using MicroShop.Catalog.Database.Interfaces;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers;

public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected readonly ICatalogDbContext DbContext;

    protected QueryHandlerBase(ICatalogDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public abstract ValueTask<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}