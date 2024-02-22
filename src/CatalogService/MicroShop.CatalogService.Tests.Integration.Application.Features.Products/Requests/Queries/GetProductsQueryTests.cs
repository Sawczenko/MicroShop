using FluentAssertions;
using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Tests.Integration.Tools;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.Products.Requests.Queries
{
    public class GetProductsQueryTests : BaseIntegrationTest
    {
        public GetProductsQueryTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProducts_ShouldReturnProducts_WhenProductsArePresentInDatabase()
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

            var product = new Product
            {
                Name = "Product",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrand = productBrand,
                ProductType = productType
            };

            dbContext.Products.Add(product);

            dbContext.SaveChanges();

            var query = new GetProductsQuery();


            //Act
            var pagedProductList = await Sender.Send(query);


            //Assert
            pagedProductList.Items.Count.Should().Be(1);

            var actualProduct = pagedProductList.Items.First();

            actualProduct.Name.Should().Be(product.Name);

            actualProduct.ProductBrand.Should().NotBe(null);
            actualProduct.ProductBrand.Name.Should().Be(product.ProductBrand.Name);

            actualProduct.ProductType.Should().NotBe(null);
            actualProduct.ProductType.Name.Should().Be(product.ProductType.Name);

            actualProduct.Price.Should().Be(1);

            actualProduct.PictureUrl.Should().Be("Url");
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenProductsAreNotPresentInDatabase()
        {
            //Arrange
            var dbContext = GetCatalogDbContext();
            var test = dbContext.Database.GetConnectionString();
            var query = new GetProductsQuery();
            //Act
            var pagedProductList = await Sender.Send(query);

            //Assert
            pagedProductList.Count.Should().Be(0);
            pagedProductList.Items.FirstOrDefault().Should().Be(null);
        }
    }
}
