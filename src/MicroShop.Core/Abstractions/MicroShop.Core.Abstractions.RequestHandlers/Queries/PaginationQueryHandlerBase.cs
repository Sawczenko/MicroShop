using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Requests.Queries;

namespace MicroShop.Catalog.Application.Abstractions.Handlers.Queries
{
    public abstract class PaginationQueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected readonly IPaginationQueryServicesContainer PaginationQueryServicesContainer;

        protected PaginationQueryHandlerBase(IPaginationQueryServicesContainer paginationQueryServicesContainer) : base(paginationQueryServicesContainer)
        {
            PaginationQueryServicesContainer = paginationQueryServicesContainer;
        }
    }
}
