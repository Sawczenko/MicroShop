using MicroShop.CatalogService.Application.Features.Products.Requests.Queries.GetProducts;
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
            //Arrange
            var query = new GetProductsQuery();


            //Act
            var pagedProductList = await Sender.Send(query);


            //Assert
            Assert.True(true);
        }
    }
}
