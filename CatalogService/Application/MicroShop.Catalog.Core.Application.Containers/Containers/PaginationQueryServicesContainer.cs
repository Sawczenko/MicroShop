using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;

namespace MicroShop.Catalog.Core.Application.Containers.Containers
{
    public class PaginationQueryServicesContainer : QueryServicesContainer, IPaginationQueryServicesContainer
    {

        public IPaginationService Pagination { get; set; }

        public PaginationQueryServicesContainer(ICatalogDbContext catalogDbContext, IPaginationService pagination) : base(catalogDbContext)
        {
            Pagination = pagination;
        }

    }
}
