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

            dbContext.ProductBrands.Add(productBrand);
            dbContext.ProductTypes.Add(productType);

            dbContext.SaveChanges();

            var firstProduct = new Product
            {
                Name = "Product",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrandId = productBrand.Id,
                ProductTypeId = productType.Id
            };

            var secondProduct = new Product
            {
                Name = "SecondProduct",
                Description = "Description",
                Price = 1,
                PictureUrl = "Url",
                ProductBrandId = productBrand.Id,
                ProductTypeId = productType.Id
            };

            dbContext.SaveChanges();

            dbContext.Products.AddRange(firstProduct, secondProduct);

            dbContext.SaveChanges();

            var manager = new GetProductsManager();

            #endregion Arrange 

            #region Act

            var result = await Sender.Send(manager);

            var pagedProductList = result.Result;

            #endregion Act

            #region Assert

            pagedProductList.Items.Count.Should().Be(2);

            var actualProduct = pagedProductList.Items.First();

            actualProduct.Name.Should().Be(firstProduct.Name);

            actualProduct.ProductBrand.Should().NotBeNull();
            actualProduct.ProductBrand.Name.Should().Be(firstProduct.ProductBrand.Name);

            actualProduct.ProductType.Should().NotBeNull();
            actualProduct.ProductType.Name.Should().Be(firstProduct.ProductType.Name);

            actualProduct.Price.Should().Be(1);

            actualProduct.PictureUrl.Should().Be("Url");

            #endregion Assert
        }


        [Fact]
        public async Task GetProducts_ShouldReturnEmptyProductDtoPagedList_WhenProductsArentInDatabase()
        {
            #region Arrange

            var manager = new GetProductsManager();

            #endregion

            #region Act

            var result = await Sender.Send(manager);

            var pagedProductList = result.Result;

            #endregion

            #region Assert

            pagedProductList.Should().NotBeNull();
            pagedProductList.Items.Should().NotBeNull();
            pagedProductList.Items.Should().BeEmpty();

            #endregion
        }
    }
}
