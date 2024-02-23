using FluentAssertions;
using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
using MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Queries.GetProductTypes;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Domain.Entities.Products;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Tests.Integration.Tools;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.ProductTypes.Requests.Queries
{
    public class GetProductTypesQueryTests : BaseIntegrationTest
    {
        public GetProductTypesQueryTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProductTypes_ShouldReturnProductTypes_WhenProductTypesArePresentInDatabase()
        {
            #region Arrange
            var dbContext = GetCatalogDbContext();

            var productTypes = new List<ProductType>
            {
                new ProductType{ Name = "TypeA"},
                new ProductType{ Name = "TypeB"},
                new ProductType{ Name = "TypeC"}
            };

            dbContext.ProductTypes.AddRange(productTypes);
            dbContext.SaveChanges();

            var query = new GetProductTypesQuery();
            #endregion Arrange

            #region Act

            var actualProductTypes = await Sender.Send(query);

            #endregion Act

            #region Assert

            actualProductTypes.Should().NotBeNullOrEmpty();
            actualProductTypes.Count.Should().Be(3);

            var actualProduct = actualProductTypes.First();
            actualProduct.Name.Should().Be("TypeA");

            #endregion Assert
        }

        [Fact]
        public async Task GetProductTypes_ShouldReturnEmptyList_WhenProductTypesAreNotPresentInDatabase()
        {
            #region Arrange

            var query = new GetProductTypesQuery();

            #endregion Arrange

            #region Act

            var actualProductTypes = await Sender.Send(query);

            #endregion Act

            #region Assert

            actualProductTypes.Should().NotBeNull();
            actualProductTypes.Should().BeEmpty();

            #endregion Assert
        }
    }
}
