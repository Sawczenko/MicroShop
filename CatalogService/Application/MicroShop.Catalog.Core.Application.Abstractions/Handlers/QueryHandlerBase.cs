using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers;

public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected readonly ICatalogDbContext DbContext;

    protected QueryHandlerBase(IQueryServicesContainer queryServicesContainer)
    {
        DbContext = queryServicesContainer.CatalogDbContext;
    }

    public abstract ValueTask<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}