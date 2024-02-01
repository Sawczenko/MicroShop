using MicroShop.CatalogService.Application.Features.Products.Requests.Managers.GetProducts;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Tests.Integration.Tools;
using FluentAssertions;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.Products.Requests.Managers
{
    public class GetProductsManagerTests : BaseIntegrationTest
    {
        public GetProductsManagerTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProducts_ShouldReturnProductDtoPagedList_WhenProductsAreInDatabase()
        {
            //Arrange
            var dbContext = GetCatalogDbContext();

            var productBrand = new ProductBrand
            {
                Name = "Brand"
            };

            var productType = new ProductType
            {
                Name = "Type"
            };

            dbContext.ProductBrands.Add(productBrand);
            dbContext.ProductTypes.Add(productType);

            dbContext.SaveChanges();

            dbContext.Products.AddRange(new Product
            {
                Name = "Product",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrandId = productBrand.Id,
                ProductTypeId = productType.Id
            }, new Product
            {
                Name = "SecondProduct",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrandId = productBrand.Id,
                ProductTypeId = productType.Id
            });

            dbContext.SaveChanges();
            var manager = new GetProductsManager();

            //Act
            var result = await Sender.Send(manager);

            //Assert
            result.Result.Count.Should().Be(2);
            result.Result.Items.First().Name.Should().Be("Product");
        }
    }
}
