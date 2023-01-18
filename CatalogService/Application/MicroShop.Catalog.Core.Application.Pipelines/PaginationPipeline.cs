using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Core.Application.Models;
using Microsoft.AspNetCore.Http;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Pipelines
{
    internal class PaginationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IPaginationQuery<TResponse>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPagination pagination;

        public PaginationPipeline(IHttpContextAccessor httpContextAccessor,IPagination pagination)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.pagination = pagination;
        }

        public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
        {

            Pagination paginationFromHeader = GetPaginationFromHeader();

            var response = await next(message, cancellationToken);

            return response;
        }

        private Pagination GetPaginationFromHeader()
        {
            var headers = httpContextAccessor.HttpContext.Request.Headers;

            var paginationExists = headers.ContainsKey("Pagination");

            if (paginationExists)
            {
                var pagination = headers["Pagination"];
            }

            return new Pagination();
        }

    }
}
