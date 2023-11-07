using MicroShop.Core.Interfaces.Services.Mapper;
using MapsterMapper;

namespace MicroShop.IdentityService.Application.Services.Mapper.Mapper
{
    internal class MapperService : IMapperService
    {
        private readonly IMapper mapper;

        public MapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public T Map<T>(object sourceObject)
        {
            return mapper.Map<T>(sourceObject);
        }
    }
}
