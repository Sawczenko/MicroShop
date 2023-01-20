using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers
{
    public interface IQueryServicesContainer
    {

        public ICatalogDbContext CatalogDbContext { get; set; }

    }
}
