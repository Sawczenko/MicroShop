using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Database;
using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;

namespace MicroShop.Catalog.Core.Application.Containers.Containers
{
    internal class PaginationQueryServicesContainer : QueryServicesContainer, IPaginationQueryServicesContainer
    {

        public IPaginationService PaginationService { get; set; }

        public PaginationQueryServicesContainer(ICatalogDbContext catalogDbContext, IPaginationService paginationService) : base(catalogDbContext)
        {
            PaginationService = paginationService;
        }

    }
}
