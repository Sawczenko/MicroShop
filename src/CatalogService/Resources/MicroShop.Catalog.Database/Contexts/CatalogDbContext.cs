using MicroShop.Catalog.Database.Entities.ProductBrands;
using MicroShop.Catalog.Database.Entities.ProductTypes;
using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Core.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Database.Contexts
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
