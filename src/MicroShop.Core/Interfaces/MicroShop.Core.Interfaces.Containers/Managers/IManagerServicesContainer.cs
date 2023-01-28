using MicroShop.Core.Interfaces.Services;
using MediatR;

namespace MicroShop.Core.Interfaces.Containers.Managers
{
    public interface IManagerServicesContainer
    {

        public IMapperService MapperService { get; set; }

        public IMediator Mediator { get; set; }

    }
}
