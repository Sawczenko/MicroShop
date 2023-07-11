using MicroShop.CatalogService.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.CatalogService.Domain.Entities.ProductBrands
{
    public class ProductBrand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}