using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserRoles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Queries.GetUserRoles
{
    public class GetUserRolesTests
    {
        private readonly UserManager<MicroShopUser> _userManager;

        public GetUserRolesTests()
        {

            var dbContext = Substitute.For<IdentityDbContext>();

            IUserStore<MicroShopUser> userStore =
                new UserStore<MicroShopUser, IdentityRole<int>, IdentityDbContext, int>(dbContext);

            _userManager = Substitute.For<UserManager<MicroShopUser>>(userStore, default, default, default, default, default, default, default, default);
        }

        [Fact]
        public async Task GetUserRoles_UserHasRoles_ReturnRoles()
        {
            //Arrange
            var roleName = "TestRole";

            _userManager.GetRolesAsync(Arg.Any<MicroShopUser>()).Returns(new List<string>
            {
                roleName
            });

            var getUserRolesQuery = new GetUserRolesQuery(new MicroShopUser());
            var getUserRolesQueryHandler = new GetUserRolesQueryHandler(_userManager);

            //Act

            var result = await getUserRolesQueryHandler.Handle(getUserRolesQuery, CancellationToken.None);

            //Assert
            result[0].Should().Be(roleName);
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task GetUserRoles_UserHasNoRoles_ReturnEmptyRolesList()
        {
            //Arrange
            var roleName = "TestRole";

            _userManager.GetRolesAsync(Arg.Any<MicroShopUser>()).Returns(new List<string>());

            var getUserRolesQuery = new GetUserRolesQuery(new MicroShopUser());
            var getUserRolesQueryHandler = new GetUserRolesQueryHandler(_userManager);

            //Act

            var result = await getUserRolesQueryHandler.Handle(getUserRolesQuery, CancellationToken.None);

            //Assert
            result.Count.Should().Be(0);
        }
    }
}
