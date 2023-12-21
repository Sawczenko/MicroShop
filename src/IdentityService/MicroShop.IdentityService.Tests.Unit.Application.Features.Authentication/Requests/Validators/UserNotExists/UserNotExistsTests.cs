using FluentAssertions;
using MicroShop.Core.Errors;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserNotExists;
using MicroShop.IdentityService.Domain.Entities.Users;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Validators.UserNotExists
{
    public class UserNotExistsTests
    {
        [Fact]
        public async Task UserNotExistsValidator_WhenTestUserExists_Return_UserTestAlreadyExists()
        {
            //Arrange

            MicroShopUser user = new MicroShopUser
            {
                UserName = "Test"
            };

            var userNotExistsValidator = new UserNotExistsValidator(user, "Test");
            var userNotExistsValidatorHandler = new UserNotExistsValidatorHandler();

            //Act

            var result =
                await userNotExistsValidatorHandler.Handle(userNotExistsValidator, CancellationToken.None);
;
            //Assert

            result.Error.Name.Should().Be(nameof(AuthenticationErrors.MICROSHOP_USER_ALREADY_EXISTS));

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task UserExistsValidator_WhenTestUserExists_Return_SuccessResult()
        {
            //Arrange

            MicroShopUser user = new MicroShopUser
            {
                UserName = "Test"
            };

            var userExistsValidator = new UserExistsValidator(user, "Test");
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
