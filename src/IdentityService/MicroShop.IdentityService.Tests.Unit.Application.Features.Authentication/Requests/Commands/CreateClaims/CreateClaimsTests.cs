using System.Security.Claims;
using FluentAssertions;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateClaims;
using Microsoft.IdentityModel.JsonWebTokens;
using Xunit;

namespace MicroShop.IdentityService.Tests.Unit.Application.Features.Authentication.Requests.Commands.CreateClaims
{
    public class CreateClaimsTests
    {

        public CreateClaimsTests()
        {
            
        }

        [Fact]
        public async Task CreateClaims_WhenUserHasRoles_CreateClaims()
        {
            //Arrange
            string userName = "TestUser";

            var roles = new List<string>
            {
                "ClaimA",
                "ClaimB"
            };

            var createClaimsCommand = new CreateClaimsCommand(userName, roles);
            var createClaimsCommandHandler = new CreateClaimsCommandHandler();

            //Act

            var result = await createClaimsCommandHandler.Handle(createClaimsCommand, CancellationToken.None);

            //Assert

            var expectedRoles = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "ClaimA"),
                new Claim(ClaimTypes.Role, "ClaimB")
            };

            result.IsSuccessful.Should().BeTrue();
            result.Result.Select(x => x.Value).Should().Contain(expectedRoles.Select(x=>x.Value));
        }

    }
}
