using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers
{
    public interface IManagerServicesContainer
    {

        public IMapperService MapperService { get; set; }

        public IMediator Mediator { get; set; }

    }
}
