namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services
{
    public interface IMapperService
    {

        T Map<T>(object sourceObject);

    }
}
