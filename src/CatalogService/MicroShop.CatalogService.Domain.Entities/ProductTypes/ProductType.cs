using MicroShop.CatalogService.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.CatalogService.Domain.Entities.ProductTypes
{
    public class ProductType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}