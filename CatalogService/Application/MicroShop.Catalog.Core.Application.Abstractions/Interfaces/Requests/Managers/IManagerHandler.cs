using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Managers
{
    public interface IManagerHandler<TManager> : IRequestHandler<TManager>
    where TManager : IManager{ }

    public interface IManagerHandler<TManager, TResponse> : IRequestHandler<TManager, TResponse>
        where TManager : IManager<TResponse> { }
}
