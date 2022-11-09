using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces;

public interface IQueryRequest<out TResponse> : IRequest<TResponse> { }