using FluentAssertions;
using MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Managers.GetProductBrands;
using MicroShop.CatalogService.Domain.Entities.ProductBrands;
using MicroShop.CatalogService.Tests.Integration.Tools;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.ProductBrands.Requests.Managers
{
    public class GetProductBrandsManagerTests : BaseIntegrationTest
    {
        public GetProductBrandsManagerTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProductBrands_ShouldReturnProductBrandsDtoList_WhenProductBrandsAreInDatabase()
        {
            #region Arrange

            var dbContext = GetCatalogDbContext();

            var productBrands = new List<ProductBrand>
            {
               new ProductBrand{ Name = "BrandA"},
               new ProductBrand{ Name = "BrandB"},
               new ProductBrand{ Name = "BrandC"}
            };

            dbContext.ProductBrands.AddRange(productBrands);
            dbContext.SaveChanges();

            var manager = new GetProductBrandsManager();

            #endregion Arrange 

            #region Act

            var result = await Sender.Send(manager);

            var actualProductBrands= result.Result.ToList();

            #endregion Act

            #region Assert

            actualProductBrands.Should().NotBeNullOrEmpty();
            actualProductBrands.Count().Should().Be(3);

            #endregion Assert
        }


        [Fact]
        public async Task GetProductBrands_ShouldReturnEmptyProductBrandsDtoList_WhenProductBrandsArentInDatabase()
        {
            #region Arrange

            var manager = new GetProductBrandsManager();

            #endregion Arrange 

            #region Act

            var result = await Sender.Send(manager);

            var actualProductBrands = result.Result.ToList();

            #endregion Act

            #region Assert

            actualProductBrands.Should().NotBeNull();
            actualProductBrands.Should().BeEmpty();

            #endregion Assert
        }
    }
}
