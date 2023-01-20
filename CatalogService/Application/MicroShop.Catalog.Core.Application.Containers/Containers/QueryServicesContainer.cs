using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;

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
