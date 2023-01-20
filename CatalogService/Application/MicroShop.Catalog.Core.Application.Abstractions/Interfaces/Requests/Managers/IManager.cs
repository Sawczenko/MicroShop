using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Managers
{
    public interface IManager : IRequest { }

    public interface IManager<TResponse> : IRequest<TResponse> { }
}
