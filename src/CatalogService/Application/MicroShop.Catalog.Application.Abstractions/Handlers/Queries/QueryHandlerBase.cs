using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Requests.Queries;
using MicroShop.Core.Interfaces.Database;
using MediatR;

namespace MicroShop.Catalog.Application.Abstractions.Handlers.Queries;

public abstract class QueryHandlerBase<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected readonly IDbContext DbContext;

    protected QueryHandlerBase(IQueryServicesContainer queryServicesContainer)
    {
        DbContext = queryServicesContainer.DbContext;
    }

    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}