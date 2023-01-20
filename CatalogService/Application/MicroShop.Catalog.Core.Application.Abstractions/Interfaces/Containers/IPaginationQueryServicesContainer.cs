using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Containers
{
    public interface IPaginationQueryServicesContainer : IQueryServicesContainer
    {

        public IPaginationService Pagination { get; set; }

    }
}
