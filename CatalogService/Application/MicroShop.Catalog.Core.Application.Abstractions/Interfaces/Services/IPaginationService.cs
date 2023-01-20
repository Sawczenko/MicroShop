namespace MicroShop.Catalog.Core.Application.Abstractions.Interfaces.Services
{
    public interface IPaginationService
    {

        public int Pages { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
