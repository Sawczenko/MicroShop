using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MicroShop.CatalogService.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public virtual ProductType ProductType { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public virtual ProductBrand ProductBrand { get; set; }

        [Required]
        public int ProductBrandId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
