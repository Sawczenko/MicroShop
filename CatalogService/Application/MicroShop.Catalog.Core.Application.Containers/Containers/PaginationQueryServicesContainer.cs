using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Core.Application.Containers.Interfaces;
using MicroShop.Catalog.Database.Interfaces;

namespace MicroShop.Catalog.Core.Application.Containers.Containers
{
    internal class PaginationQueryServicesContainer : IPaginationQueryServicesContainer
    {
        public IPagination IPagination { get ; set; }
        public ICatalogDbContext CatalogDbContext { get ; set; }

        public PaginationQueryServicesContainer(ICatalogDbContext catalogDbContext, IPagination pagination)
        {
            CatalogDbContext = catalogDbContext;
            IPagination = pagination;
        }

    }
}
