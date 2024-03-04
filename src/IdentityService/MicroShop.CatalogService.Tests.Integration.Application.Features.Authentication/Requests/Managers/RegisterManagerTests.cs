using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Tests.Integration.Tools;
using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Models.Responses;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;

namespace MicroShop.CatalogService.Tests.Integration.Application.Features.Authentication.Requests.Managers
{
    public class RegisterManagerTests : BaseIntegrationTest
    {

        private const string RegisterEndpoint = "api/Authentication/Register";

        public RegisterManagerTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnUserCreatedSuccessfully_WhenUserMeetRequirements()
        {
            #region Arrange

            string userName = "TestUser";
            string password = "zaq1@WSX";
            string email = "sampleemail@test.pl";

            #endregion Arrange

            #region Act

            var request = new RegisterManagerRequest
            {
                Email = email,
                Password = password,
                UserName = userName
            };

            var response = await Client.PostAsJsonAsync(RegisterEndpoint, request);


            var apiResponse = await response.Content.ReadFromJsonAsync<ApplicationResponse<RegisterResponseDto>>();

            #endregion Act

            #region Assert

            apiResponse.Should().NotBeNull();
            apiResponse?.IsSuccessful.Should().BeTrue();
            apiResponse?.Result.Successful.Should().BeTrue();
            apiResponse?.Result.Message.Should().Be("User created Successfully!");
            #endregion Assert
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnUserExistsError_WhenUserNameIsClaimed()
        {
            #region Arrange

            string userName = "TestUser";
            string password = "zaq1@WSX";
            string email = "sampleemail@test.pl";

            MicroShopUser testUser = new MicroShopUser()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userName
            };

            var creationResult = await UserManager.CreateAsync(testUser, password);

            creationResult.Succeeded.Should().BeTrue();

            #endregion Arrange

            #region Act

            var request = new RegisterManagerRequest
            {
                Email = email,
                Password = password,
                UserName = userName
            };

            var response = await Client.PostAsJsonAsync(RegisterEndpoint, request);


            var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

            #endregion Act

            #region Assert

            errorResponse.Should().NotBeNull();
            errorResponse?.ErrorCode.Should().Be(AuthenticationErrors.MICROSHOP_USER_ALREADY_EXISTS);
            errorResponse?.Message.Should().Be(AuthenticationErrors.MICROSHOP_USER_ALREADY_EXISTS.Message);

            #endregion Assert
        }
    }
}
