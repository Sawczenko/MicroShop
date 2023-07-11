using System.ComponentModel.DataAnnotations;

namespace MicroShop.CatalogService.Application.DataTransferObjects
{
    public class ProductBrandDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
