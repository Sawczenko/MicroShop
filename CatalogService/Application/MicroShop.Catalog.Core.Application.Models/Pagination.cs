using MicroShop.Catalog.Core.Application.Abstractions.Interfaces;

namespace MicroShop.Catalog.Core.Application.Models
{
    public class Pagination : IPagination
    {

        public Pagination()
        {
            Pages = 1;
            PageSize = 50;
        }

        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
