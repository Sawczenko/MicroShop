using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers.Queries
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
