﻿using MicroShop.Catalog.Database.Entities.Products;
using MicroShop.Catalog.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using MicroShop.Catalog.Database.Entities.ProductBrands;
using MicroShop.Catalog.Database.Entities.ProductTypes;

namespace MicroShop.Catalog.Database.Contexts
{
    internal class CatalogDbContext : DbContext, ICatalogDbContext
    {

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductBrand> ProductBrands { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) 
            : base(options) { }

    }
}
