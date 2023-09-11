using MicroShop.CatalogService.Domain.Entities.ProductBrands;

namespace MicroShop.CatalogService.Database.Seeds
{
    internal class ProductBrandSeed
    {
        internal List<ProductBrand> GetProductBrandSeeds()
        {
            return new List<ProductBrand>
            {
                new ProductBrand
                {
                    Id = 1,
                    Name = "Larian Studios"
                },
                new ProductBrand
                {
                    Id= 2,
                    Name = "Amica"
                }
            };
        }
    }
}
