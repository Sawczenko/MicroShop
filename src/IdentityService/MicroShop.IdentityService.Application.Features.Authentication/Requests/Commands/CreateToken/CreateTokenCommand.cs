using MicroShop.Core.Interfaces.Requests.Command;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateToken;

internal sealed record CreateTokenCommand : ICommand<string>
{
    internal IList<Claim> Claims { get; }

    public CreateTokenCommand(IList<Claim> claims)
    {
        Claims = claims;
    }
}