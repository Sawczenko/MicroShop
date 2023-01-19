using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Containers.Interfaces
{
    public interface IQueryServicesContainer
    {

        public ICatalogDbContext CatalogDbContext { get; set; }

    }
}
