using FluentAssertions;
using MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Queries.GetProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Tests.Integration.Tools;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.ProductBrands.Requests.Queries
{
    public class GetProductBrandsQueryTests : BaseIntegrationTest
    {
        public GetProductBrandsQueryTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProductBrands_ShouldReturnProductBrands_WhenProductBrandsArePresentInDatabase()
        {
            #region Arrange
            var dbContext = GetCatalogDbContext();

            var ProductBrands = new List<ProductBrand>
            {
                new ProductBrand{ Name = "BrandA"},
                new ProductBrand{ Name = "BrandB"},
                new ProductBrand{ Name = "BrandC"}
            };

            dbContext.ProductBrands.AddRange(ProductBrands);
            dbContext.SaveChanges();

            var query = new GetProductBrandsQuery();
            #endregion Arrange

            #region Act

            var actualProductBrands = await Sender.Send(query);

            #endregion Act

            #region Assert

            actualProductBrands.Should().NotBeNullOrEmpty();
            actualProductBrands.Count.Should().Be(3);

            var actualProduct = actualProductBrands.First();
            actualProduct.Name.Should().Be("BrandA");

            #endregion Assert
        }

        [Fact]
        public async Task GetProductBrands_ShouldReturnEmptyList_WhenProductBrandsAreNotPresentInDatabase()
        {
            #region Arrange

            var query = new GetProductBrandsQuery();

            #endregion Arrange

            #region Act

            var actualProductBrands = await Sender.Send(query);

            #endregion Act

            #region Assert

            actualProductBrands.Should().NotBeNull();
            actualProductBrands.Should().BeEmpty();

            #endregion Assert
        }
    }
}
