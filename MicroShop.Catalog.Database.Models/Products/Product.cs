﻿using MicroShop.Catalog.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MicroShop.Catalog.Database.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public virtual ProductType ProductType { get; set; }

        [Required]
        public int ProductTypeID { get; set; }

        [Required]
        public virtual ProductBrand ProductBrand { get; set; }

        [Required]
        public  int ProductBrandID { get; set; }
    }
}
