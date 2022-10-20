using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Catalog.Database.Contexts
{
    internal class CatalogDbContext : DbContext, ICatalogDbContext
    {

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductBrand> ProductBrands { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

    }
}
