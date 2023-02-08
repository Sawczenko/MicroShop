using MicroShop.Core.Interfaces.Containers.Queries;
using MicroShop.Core.Interfaces.Database;

namespace MicroShop.Catalog.Application.Containers.Containers
{
    internal class QueryServicesContainer : IQueryServicesContainer
    {
        public IDbContext DbContext { get; set; }

        public QueryServicesContainer(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
