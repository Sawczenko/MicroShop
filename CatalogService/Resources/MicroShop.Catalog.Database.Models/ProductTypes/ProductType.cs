using MicroShop.Catalog.Database.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MicroShop.Catalog.Database.Entities.ProductTypes
{
    public class ProductType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}