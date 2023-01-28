using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Requests.Queries;
using MicroShop.Core.Interfaces.Services;

namespace MicroShop.Catalog.Application.Abstractions.Handlers.Queries
{
    public abstract class PaginationQueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected readonly IPaginationService PaginationService;

        protected PaginationQueryHandlerBase(IPaginationQueryServicesContainer paginationQueryServicesContainer) : base(paginationQueryServicesContainer)
        {
            PaginationService = paginationQueryServicesContainer.PaginationService;
        }
    }
}
