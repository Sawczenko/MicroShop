using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Containers.Containers
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
