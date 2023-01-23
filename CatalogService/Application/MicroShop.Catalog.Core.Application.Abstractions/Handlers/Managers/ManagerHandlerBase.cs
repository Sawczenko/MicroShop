using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Requests.Managers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Handlers.Managers
{
    public abstract class ManagerHandlerBase<TManager> : IManagerHandler<TManager>
        where TManager : IManager
    {

        protected readonly IMediator Mediator;

        protected readonly IMapperService MapperService;

        protected ManagerHandlerBase(IManagerServicesContainer managerServicesContainer)
        {
            Mediator = managerServicesContainer.Mediator;
            MapperService = managerServicesContainer.MapperService;
        }

        public abstract ValueTask<Unit> Handle(TManager request, CancellationToken cancellationToken);
    }

    public abstract class ManagerHandlerBase<TManager, TResponse> : IManagerHandler<TManager, TResponse>
        where TManager : IManager<TResponse>
    {

        protected readonly IMediator Mediator;

        protected readonly IMapperService MapperService;

        protected ManagerHandlerBase(IManagerServicesContainer managerServicesContainer)
        {
            Mediator = managerServicesContainer.Mediator;
            MapperService = managerServicesContainer.MapperService;
        }

        public abstract ValueTask<TResponse> Handle(TManager request, CancellationToken cancellationToken);
    }

}
