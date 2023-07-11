using System.ComponentModel.DataAnnotations;

namespace MicroShop.CatalogService.Application.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public float Price { get; set; }

        public string PictureUrl { get; set; }

        public virtual ProductTypeDto ProductType { get; set; }

        public int ProductTypeID { get; set; }

        public virtual ProductBrandDto ProductBrand { get; set; }

        public int ProductBrandID { get; set; }

        public string Description { get; set; }
    }
}