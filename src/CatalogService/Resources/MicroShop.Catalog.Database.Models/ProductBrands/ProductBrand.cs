using MicroShop.Catalog.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Catalog.Database.Entities.ProductBrands
{
    public class ProductBrand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}