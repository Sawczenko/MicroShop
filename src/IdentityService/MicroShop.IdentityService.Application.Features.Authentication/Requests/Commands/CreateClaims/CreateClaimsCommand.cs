using System.Security.Claims;
using MicroShop.Core.Interfaces.Requests.Command;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateClaims;

internal sealed record CreateClaimsCommand : ICommand<IList<Claim>>
{
    internal string UserName { get; }

    internal IList<string> UserRoles { get; }

    public CreateClaimsCommand(string userName, IList<string> userRoles)
    {
        UserName = userName;
        UserRoles = userRoles;
    }
}