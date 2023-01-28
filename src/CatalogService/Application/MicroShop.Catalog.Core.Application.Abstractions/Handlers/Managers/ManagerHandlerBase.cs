using MicroShop.Core.Interfaces.RequestHandlers.Managers;
using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Interfaces.Requests.Managers;
using MicroShop.Core.Interfaces.Services;
using MediatR;

namespace MicroShop.Catalog.Application.Abstractions.Handlers.Managers
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
        public abstract Task<Unit> Handle(TManager request, CancellationToken cancellationToken);
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

        public abstract Task<TResponse> Handle(TManager request, CancellationToken cancellationToken);
    }

}
