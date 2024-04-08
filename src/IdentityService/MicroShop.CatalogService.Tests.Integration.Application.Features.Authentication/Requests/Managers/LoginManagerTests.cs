using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Tests.Integration.Tools;
using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Models.Responses;
using System.Net.Http.Json;
using FluentAssertions;
using System.Net;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.Authentication.Requests.Managers
{
    public class LoginManagerTests : BaseIntegrationTest
    {

        private const string LoginEndpoint = "api/Authentication/Login";

        public LoginManagerTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Login_ShouldReturnToken_WhenLoginIsSuccessfull()
        {
            #region Arrange

            string userName = "TestUser";
            string password = "zaq1@WSX";
            string email = "sampleemail@test.pl";

            var user = new MicroShopUser
            {
                UserName = userName,
                Email = email
            };

            var creationResult = await UserManager.CreateAsync(user, password);

            creationResult.Succeeded.Should().BeTrue();

            #endregion Arrange

            #region Act

            var request = new LoginManagerRequest
            {
                UserName = user.UserName,
                Password = password
            };

            var response = await Client.PostAsJsonAsync(LoginEndpoint, request);


            var apiResponse = await response.Content.ReadFromJsonAsync<ApplicationResponse<LoginResponseDto>>();

            #endregion Act

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            apiResponse.Should().NotBeNull();       
            apiResponse?.IsSuccessful.Should().BeTrue();
            apiResponse?.Result.Token.Should().NotBeNullOrEmpty();
            
            #endregion Assert
        }

        [Fact]
        public async Task Login_ShouldReturnUserNotExistsError_WhenUserNotExists()
        {
            #region Arrange

            string userName = "TestUser";
            string password = "zaq1@WSX";

            #endregion Arrange

            #region Act

            var request = new LoginManagerRequest
            {
                Password = password,
                UserName = userName
            };

            var response = await Client.PostAsJsonAsync(LoginEndpoint, request);


            var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

            #endregion Act

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            errorResponse.Should().NotBeNull();
            errorResponse.ErrorCode.Should().Be(AuthenticationErrors.MICROSHOP_USER_DOES_NOT_EXIST);
            errorResponse.Message.Should().Contain(userName);

            #endregion Assert
        }

        [Fact]
        public async Task Login_ShouldReturnUserPasswordIsNotCorrectError_WhenUserPasswordIsIncorrect()
        {
            #region Arrange

            string userName = "TestUser";
            string password = "zaq1@WSX";
            string email = "sampleemail@test.pl";

            var user = new MicroShopUser
            {
                UserName = userName,
                Email = email
            };

            var creationResult = await UserManager.CreateAsync(user, password);

            creationResult.Succeeded.Should().BeTrue();

            #endregion Arrange

            #region Act

            var request = new LoginManagerRequest
            {
                UserName = user.UserName,
                Password = password + "test" 
            };

            var response = await Client.PostAsJsonAsync(LoginEndpoint, request);


            var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

            #endregion Act

            #region Assert

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            errorResponse.Should().NotBeNull();
            errorResponse?.ErrorCode.Should().Be(AuthenticationErrors.MICROSHOP_USER_PASSWORD_IS_NOT_CORRECT);
            errorResponse?.Message.Should().Contain(userName);

            #endregion Assert
        }
    }
}
