using FluentAssertions;
using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Tests.Integration.Tools;
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
            #region Arrange
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
            #endregion Arrange

            #region Act

            var pagedProductList = await Sender.Send(query);

            #endregion Act

            #region Assert

            pagedProductList.Items.Count.Should().Be(1);

            var actualProduct = pagedProductList.Items.First();

            actualProduct.Name.Should().Be(product.Name);

            actualProduct.ProductBrand.Should().NotBe(null);
            actualProduct.ProductBrand.Name.Should().Be(product.ProductBrand.Name);

            actualProduct.ProductType.Should().NotBe(null);
            actualProduct.ProductType.Name.Should().Be(product.ProductType.Name);

            actualProduct.Price.Should().Be(1);

            actualProduct.PictureUrl.Should().Be("Url");

            #endregion Assert
        }

        [Fact]
        public async Task GetProducts_ShouldReturnEmptyList_WhenProductsAreNotPresentInDatabase()
        {
            #region Arrange

            var dbContext = GetCatalogDbContext();

            var query = new GetProductsQuery();

            #endregion Arrange

            #region Act

            var pagedProductList = await Sender.Send(query);

            #endregion Act

            #region Assert

            pagedProductList.Should().NotBeNull();
            pagedProductList.Items.Should().NotBeNull();
            pagedProductList.Items.Should().BeEmpty();

            #endregion Assert
        }
    }
}
