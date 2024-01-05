using MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateNewUser;
using MicroShop.IdentityService.Application.Errors.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using MicroShop.Core.Errors;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Commands.CreateNewUser
{
    public class CreateNewUserTests
    {
        private readonly UserManager<MicroShopUser> _userManager;

        public CreateNewUserTests()
        {
            var dbContext = Substitute.For<IdentityDbContext>();

            IUserStore<MicroShopUser> userStore =
                new UserStore<MicroShopUser, IdentityRole<int>, IdentityDbContext, int>(dbContext);

            _userManager = Substitute.For<UserManager<MicroShopUser>>(userStore, default, default, default, default, default, default, default, default);
        }

        [Fact]
        public async Task CreateNewUserCommand_WhenUserCreationSucceded_ReturnSuccess()
        {
            //Arrange

            _userManager.CreateAsync(Arg.Any<MicroShopUser>(), Arg.Any<string>()).Returns(IdentityResult.Success);

            var createNewUserCommand =
                new CreateNewUserCommand("Test", "Test", "Test");
            var createNewUserCommandHandler = new CreateNewUserCommandHandler(_userManager);

            //Act

            var result = await createNewUserCommandHandler.Handle(createNewUserCommand, CancellationToken.None);

            //Assert
            result.Error.Name.Should().Be(nameof(Error.ERROR_NONE));
            result.IsSuccessful.Should().BeTrue();
        }


        [Fact]
        public async Task CreateNewUserCommand_WhenUserCreationFailed_ReturnUserCreationFailed()
        {
            //Arrange

            _userManager.CreateAsync(Arg.Any<MicroShopUser>(), Arg.Any<string>()).Returns(IdentityResult.Failed());

            var createNewUserCommand =
                new CreateNewUserCommand("Test", "Test", "Test");
            var createNewUserCommandHandler = new CreateNewUserCommandHandler(_userManager);

            //Act

            var result = await createNewUserCommandHandler.Handle(createNewUserCommand, CancellationToken.None);

            //Assert
            result.Error.Name.Should().Be(nameof(AuthenticationErrors.MICROSHOP_USER_CREATION_FAILED));
            result.IsFailure.Should().BeTrue();
        }
    }
}
