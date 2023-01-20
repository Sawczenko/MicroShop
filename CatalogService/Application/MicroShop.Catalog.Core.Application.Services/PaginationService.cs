using MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services;

namespace MicroShop.Catalog.Core.Application.Abstractions.Pagination
{
    public class PaginationService : IPaginationService
    {

        public PaginationService()
        {
            Pages = 1;
            PageSize = 50;
        }

        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
