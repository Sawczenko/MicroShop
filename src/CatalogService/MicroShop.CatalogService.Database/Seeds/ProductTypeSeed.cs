using MicroShop.CatalogService.Domain.Entities.ProductTypes;

namespace MicroShop.CatalogService.Database.Seeds
{
    internal class ProductTypeSeed
    {
        internal List<ProductType> GetProductTypeSeeds()
        {
            return new List<ProductType> {
                new ProductType
                {
                    Id = 1,
                    Name = "Gra"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Pralka"
                }
            };
        }
    }
}
