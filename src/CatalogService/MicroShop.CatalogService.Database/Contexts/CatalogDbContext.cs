using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.Core.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.CatalogService.Database.Contexts
{
    internal class CatalogDbContext : DbContext, IDbContext
    {

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductBrand> ProductBrands { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }

    }
}
