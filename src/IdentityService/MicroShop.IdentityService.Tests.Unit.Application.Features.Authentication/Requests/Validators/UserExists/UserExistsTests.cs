using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Errors;
using FluentAssertions;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Validators.UserExists
{
    public class UserExistsTests
    {
        public UserExistsTests()
        {
            
        }

        [Fact]
        public async Task UserExistsValidator_WhenTestUserNotExists_Return_UserTestDoesNotExist()
        {
            //Arrange

            MicroShopUser user = default;
            string userName = "test";

            var userExistsValidator = new UserExistsValidator(user, userName);
            var userExistsValidatorHandler = new UserExistsValidatorHandler();

            //Act

            var result = await userExistsValidatorHandler.Handle(userExistsValidator, CancellationToken.None);

            //Assert

            result.Error.Name.Should().Be(nameof(AuthenticationErrors.MICROSHOP_USER_DOES_NOT_EXIST));
            result.Error.Message.Should().Contain(userName);
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task UserExistsValidator_WhenTestUserExists_Return_SuccessResult()
        {
            //Arrange

            string userName = "Test";

            MicroShopUser user = new MicroShopUser
            {
                UserName = userName
            };

            var userExistsValidator = new UserExistsValidator(user, userName);
            var userExistsValidatorHandler = new UserExistsValidatorHandler();

            //Act

            var result = await userExistsValidatorHandler.Handle(userExistsValidator, CancellationToken.None);

            //Assert

            result.Error.Name.Should().Be(nameof(Error.ERROR_NONE));
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public async Task UserExistsValidator_WhenTestUserExistsButUserNameDoesNotMatch_Return_UserUserNameDoesNotMatch()
        {
            //Arrange

            MicroShopUser user = new MicroShopUser
            {
                UserName = "Test"
            };
            var userExistsValidator = new UserExistsValidator(user, "Test2");
            var userExistsValidatorHandler = new UserExistsValidatorHandler();

            //Act

            var result = await userExistsValidatorHandler.Handle(userExistsValidator, CancellationToken.None);

            //Assert

            result.Error.Name.Should().Be(nameof(AuthenticationErrors.MICROSHOP_USER_USERNAME_DOES_NOT_MATCH));
            result.IsFailure.Should().BeTrue();
        }
    }
}
