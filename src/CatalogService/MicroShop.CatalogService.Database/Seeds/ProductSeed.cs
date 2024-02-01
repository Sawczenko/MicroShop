using MicroShop.CatalogService.Domain.Entities.Products;

namespace MicroShop.CatalogService.Database.Seeds
{
    internal class ProductSeed
    {
        internal List<Product> GetProductSeeds()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductBrandId = 1,
                    Name = "Baldur's Gate",
                    Price = 100,
                    ProductTypeId = 1,
                    PictureUrl = "TestUrl",
                    Description = "Gra ARPG"
                },
                new Product
                {
                    Id = 2,
                    ProductBrandId = 2,
                    ProductTypeId = 2,
                    Description = "Dobra pralka",
                    PictureUrl = "TestUrl",
                    Price = 1000,
                    Name = "Amica XYZ"
                }
            };
        }
    }
}
