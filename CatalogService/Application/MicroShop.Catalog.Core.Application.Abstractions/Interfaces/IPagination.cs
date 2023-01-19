namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces
{
    public interface IPagination
    {

        public int Pages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
