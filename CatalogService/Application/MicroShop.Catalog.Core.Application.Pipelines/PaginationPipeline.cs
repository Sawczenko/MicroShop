using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Queries;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using MicroShop.Catalog.Core.Application.Services.Pagination;
using Microsoft.AspNetCore.Http;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Pipelines
{
    internal class PaginationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IPaginationQuery<TResponse>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPaginationService paginationService;

        public PaginationPipeline(IHttpContextAccessor httpContextAccessor,IPaginationService paginationService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.paginationService = paginationService;
        }

        public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
        {

            PaginationService paginationServiceFromHeader = GetPaginationFromHeader();

            paginationService.CurrentPage = paginationServiceFromHeader.CurrentPage;
            paginationService.PageSize = paginationServiceFromHeader.PageSize;

            var response = await next(message, cancellationToken);

            return response;
        }

        private PaginationService GetPaginationFromHeader()
        {
            var headers = httpContextAccessor.HttpContext.Request.Headers;

            var paginationServiceExists = headers.ContainsKey("Pagination");

            if (paginationServiceExists)
            {
                //TODO Parse From Json
                var paginationService = headers["Pagination"];
            }

            return new PaginationService();
        }

    }
}
