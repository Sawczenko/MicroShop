using MicroShop.Core.Interfaces.Services;
using AutoMapper;

namespace MicroShop.Catalog.Application.Services.Mapper
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
