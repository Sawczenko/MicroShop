using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;

namespace MicroShop.Catalog.Core.Application.Containers.Interfaces
{
    internal interface IPaginationQueryServicesContainer : IQueryServicesContainer
    {

        public IPagination IPagination { get; set; }

    }
}
