using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserPassword;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login;
using MicroShop.IdentityService.Application.Errors.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using MicroShop.Core.Errors;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Validators.UserPassword
{
    public class UserPasswordTests
    {
        private readonly UserManager<MicroShopUser> _userManager;

        public UserPasswordTests()
        {
            var dbContext = Substitute.For<IdentityDbContext>();

            IUserStore<MicroShopUser> userStore =
            new UserStore<MicroShopUser, IdentityRole<int>, IdentityDbContext, int>(dbContext);

            _userManager = Substitute.For<UserManager<MicroShopUser>>(userStore, default, default, default, default, default, default, default, default);
        }

        [Fact]
        public async Task UserPassword_WhenUserPasswordIsNotCorrect_ReturnPasswordIsNotCorrect()
        {
            //Arrange
            string testString = "Test";

            MicroShopUser user = new()
            {
                UserName = testString
            };

            _userManager.CheckPasswordAsync(Arg.Any<MicroShopUser>(), Arg.Any<string>()).Returns(false);
            
            var loginManagerRequest = new LoginManagerRequest
            {
                UserName = user.UserName,
                Password = testString
            };
            var userPasswordValidator = new UserPasswordValidator(Arg.Any<MicroShopUser>(), loginManagerRequest);
            var userPasswordValidatorHandler = new UserPasswordValidatorHandler(_userManager);
            //Act
            var result = await userPasswordValidatorHandler.Handle(userPasswordValidator, CancellationToken.None);

            //Assert
            result.Error.Name.Should().Be(nameof(AuthenticationErrors.MICROSHOP_USER_PASSWORD_IS_NOT_CORRECT));
            result.Error.Message.Should().Contain(user.UserName);
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task UserPassword_WhenUserPasswordIsCorrect_ReturnSuccessResult()
        {
            //Arrange
            string testString = "Test";

            MicroShopUser user = new()
            {
                UserName = testString
            };

            _userManager.CheckPasswordAsync(user, testString).Returns(true);

            var loginManagerRequest = new LoginManagerRequest
            {
                UserName = user.UserName,
                Password = testString
            };
            var userPasswordValidator = new UserPasswordValidator(user, loginManagerRequest);
            var userPasswordValidatorHandler = new UserPasswordValidatorHandler(_userManager);

            //Act
            var result = await userPasswordValidatorHandler.Handle(userPasswordValidator, CancellationToken.None);

            //Assert
            result.Error.Name.Should().Be(nameof(Error.ERROR_NONE));
            result.IsSuccessful.Should().BeTrue();
        }
    }
}
