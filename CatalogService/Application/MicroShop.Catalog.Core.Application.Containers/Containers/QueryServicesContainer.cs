using MicroShop.Catalog.Core.Application.Containers.Interfaces;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Containers.Containers
{
    public class QueryServicesContainer : IQueryServicesContainer
    {
        public ICatalogDbContext CatalogDbContext { get; set; }

        public QueryServicesContainer(ICatalogDbContext catalogDbContext)
        {
            CatalogDbContext = catalogDbContext;
        }
    }
}
