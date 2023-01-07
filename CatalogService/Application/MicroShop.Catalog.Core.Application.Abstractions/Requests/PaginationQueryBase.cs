using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;
using MicroShop.Catalog.Core.Application.Models;

namespace MicroShop.Catalog.Core.Application.Abstractions.Requests
{
    public record PaginationQueryBase<TEntity> : IPaginationQuery<TEntity>
    {
        public Pagination Pagination { get; set; }

        protected PaginationQueryBase(Pagination pagination)
        {
            Pagination = pagination;
        }
    }
}
