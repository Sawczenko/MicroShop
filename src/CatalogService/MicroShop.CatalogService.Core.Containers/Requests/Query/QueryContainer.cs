using MicroShop.Core.Abstractions.Containers.Requests.Query;
using MicroShop.CatalogService.Core.Interfaces.Database;

namespace MicroShop.CatalogService.Core.Containers.Requests.Query
{
    public class QueryContainer : QueryContainer<ICatalogDbContext>
    {
        public ICatalogDbContext DbContext { get; set; }

        public QueryContainer(ICatalogDbContext dbContext) 
            : base(dbContext) { }
    }
}
