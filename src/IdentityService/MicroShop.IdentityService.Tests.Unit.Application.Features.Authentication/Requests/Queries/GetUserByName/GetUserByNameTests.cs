using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Queries.GetUserByName
{
    public class GetUserByNameTests
    {

        private readonly UserManager<MicroShopUser> _userManager;

        public GetUserByNameTests()
        {

            var dbContext = Substitute.For<IdentityDbContext>();

            IUserStore<MicroShopUser> userStore =
                new UserStore<MicroShopUser, IdentityRole<int>, IdentityDbContext, int>(dbContext);

            _userManager = Substitute.For<UserManager<MicroShopUser>>(userStore, default, default, default, default, default, default, default, default);
        }

        [Fact]
        public async Task GetUserByName_UserExists_ReturnUser()
        {
            //Arrange
            var userName = "TestUser";

            _userManager.FindByNameAsync(userName).Returns(new MicroShopUser
            {
                UserName = userName
            });

            var getUserByNameQuery = new GetUserByNameQuery(userName);
            var getUserByNameQueryHandler = new GetUserByNameQueryHandler(_userManager);

            //Act

            var result = await getUserByNameQueryHandler.Handle(getUserByNameQuery, CancellationToken.None);

            //Assert
            result.UserName.Should().Be(userName);
        }


        [Fact]
        public async Task GetUserByName_UserNotExists_ReturnNull()
        {
            //Arrange
            var userName = "TestUser";

            _userManager.FindByNameAsync(Arg.Any<string>()).Returns((MicroShopUser)default);

            var getUserByNameQuery = new GetUserByNameQuery(userName);
            var getUserByNameQueryHandler = new GetUserByNameQueryHandler(_userManager);

            //Act

            var result = await getUserByNameQueryHandler.Handle(getUserByNameQuery, CancellationToken.None);

            //Assert
            result.Should().Be(null);
        }
    }

}
