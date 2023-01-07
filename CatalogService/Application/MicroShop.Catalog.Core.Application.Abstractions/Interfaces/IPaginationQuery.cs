using MicroShop.Catalog.Core.Application.Models;
using Mediator;

namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces
{
    public interface IPaginationQuery<TEntity> : IQuery<TEntity>
    {

        Pagination Pagination { get; set; }

    }
}