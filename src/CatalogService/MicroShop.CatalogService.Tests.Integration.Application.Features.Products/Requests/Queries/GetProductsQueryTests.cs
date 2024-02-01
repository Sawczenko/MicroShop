using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Tests.Integration.Tools;
using FluentAssertions;
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

            dbContext.Products.Add(new Product
            {
                Name = "Product",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrand = new ProductBrand
                {
                    Name = "Brand"
                },
                ProductType = new ProductType
                {
                    Name = "Type"
                }
            });

            dbContext.SaveChanges();

            var query = new GetProductsQuery();


            //Act
            var pagedProductList = await Sender.Send(query);


            //Assert
            pagedProductList.Items.Count.Should().Be(1);
            pagedProductList.Items.First().Name.Should().Be("Product");
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenProductsAreNotPresentInDatabase()
        {
            //Arrange
            var dbContext = GetCatalogDbContext();
            var query = new GetProductsQuery();

            //Act
            var pagedProductList = await Sender.Send(query);

            //Assert
            pagedProductList.Count.Should().Be(0);
            pagedProductList.Items.FirstOrDefault().Should().Be(default);
        }
    }
}
