using MicroShop.Core.Interfaces.Services.Mapper;
using MapsterMapper;

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

        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            return mapper.Map<TSource, TDestination>(sourceObject);
        }
    }
}
