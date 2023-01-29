using MicroShop.Core.Interfaces.Services;

namespace MicroShop.Catalog.Application.Services.Pagination
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
