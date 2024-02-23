using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Core.Interfaces.Database;
using MicroShop.CatalogService.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.CatalogService.Database.Contexts
{
    public class CatalogDbContext : DbContext, ICatalogDbContext
    {

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductBrand> ProductBrands { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productTypeSeed = new ProductTypeSeed();
            var productBrandSeed = new ProductBrandSeed();
            var productsSeed = new ProductSeed();

            modelBuilder.Entity<ProductType>().HasData(productTypeSeed.GetProductTypeSeeds());

            modelBuilder.Entity<ProductBrand>().HasData(productBrandSeed.GetProductBrandSeeds());

            modelBuilder.Entity<Product>().HasData(productsSeed.GetProductSeeds());
        }
    }
}
