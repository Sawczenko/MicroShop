using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers;

public abstract class QueryHandlerBase<TRequest, TResponse, TDbContext> : IQueryRequestHandler<TRequest, TResponse>
    where TRequest : IQueryRequest<TResponse>
    where TDbContext : IDbContext
{
    protected readonly TDbContext DbContext;

    protected QueryHandlerBase(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public abstract ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}