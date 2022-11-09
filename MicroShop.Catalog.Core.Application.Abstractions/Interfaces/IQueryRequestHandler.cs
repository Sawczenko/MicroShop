using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces;

public interface IQueryRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : IQueryRequest<TResponse> { }