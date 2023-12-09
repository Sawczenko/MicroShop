using MicroShop.Core.Abstractions.Requests.ResponseCommand;
using Microsoft.IdentityModel.JsonWebTokens;
using MicroShop.Core.Models.Requests;
using System.Security.Claims;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateClaims;

internal sealed class CreateClaimsCommandHandler : CommandHandlerBase<CreateClaimsCommand, IList<Claim>>
{
    public override async Task<RequestResult<IList<Claim>>> Handle(CreateClaimsCommand command, CancellationToken cancellationToken)
    {
        var authClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, command.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in command.UserRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        return await Task.FromResult(RequestResult<IList<Claim>>.Success(authClaims));
    }
}