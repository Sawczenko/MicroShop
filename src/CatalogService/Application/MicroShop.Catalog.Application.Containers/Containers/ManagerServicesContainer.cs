using MicroShop.Core.Interfaces.Containers.Managers;
using MicroShop.Core.Interfaces.Services;
using MediatR;

namespace MicroShop.Catalog.Application.Containers.Containers
{
    internal class ManagerServicesContainer : IManagerServicesContainer
    {
        public IMapperService MapperService { get; set; }
        public IMediator Mediator { get; set; }

        public ManagerServicesContainer(IMapperService mapperService, IMediator mediator)
        {
            MapperService = mapperService;
            Mediator = mediator;
        }
    }
}
