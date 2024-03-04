using MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Managers.GetProductTypes;
using MicroShop.CatalogService.Domain.Entities.ProductTypes;
using MicroShop.CatalogService.Tests.Integration.Tools;
using FluentAssertions;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.ProductTypes.Requests.Managers
{
    public class GetProductTypesManagerTests : BaseIntegrationTest
    {
        public GetProductTypesManagerTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProductTypes_ShouldReturnProductTypesDtoList_WhenProductTypesAreInDatabase()
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

            var manager = new GetProductTypesManager();

            #endregion Arrange 

            #region Act

            var result = await Sender.Send(manager);

            var actualProductTypes= result.Result.ToList();

            #endregion Act

            #region Assert

            actualProductTypes.Should().NotBeNullOrEmpty();
            actualProductTypes.Count().Should().Be(3);

            #endregion Assert
        }


        [Fact]
        public async Task GetProductTypes_ShouldReturnEmptyProductTypesDtoList_WhenProductTypesArentInDatabase()
        {
            #region Arrange

            var manager = new GetProductTypesManager();

            #endregion Arrange 

            #region Act

            var result = await Sender.Send(manager);

            var actualProductTypes = result.Result.ToList();

            #endregion Act

            #region Assert

            actualProductTypes.Should().NotBeNull();
            actualProductTypes.Should().BeEmpty();

            #endregion Assert
        }
    }
}
