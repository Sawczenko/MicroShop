namespace MicroShop.CatalogService.Application.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string PictureUrl { get; set; }

        public  ProductTypeDto ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public  ProductBrandDto ProductBrand { get; set; }

        public int ProductBrandId { get; set; }

        public string Description { get; set; }
    }
}