using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using Mediator;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers
{
    public abstract class PaginationQueryHandlerBase<TQuery, TResponse> : QueryHandlerBase<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        public IPaginationService Pagination { get; set; }

        protected PaginationQueryHandlerBase(IPaginationQueryServicesContainer paginationQueryServicesContainer) : base(paginationQueryServicesContainer)
        {
            Pagination = paginationQueryServicesContainer.Pagination;
        }
    }
}
