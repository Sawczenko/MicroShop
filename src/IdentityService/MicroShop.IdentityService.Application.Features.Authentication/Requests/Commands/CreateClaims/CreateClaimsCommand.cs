using System.Security.Claims;
using MicroShop.Core.Interfaces.Requests.Command;
using MicroShop.IdentityService.Domain.Entities.Users;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateClaims;

internal sealed record CreateClaimsCommand : ICommand<IList<Claim>>
{
    internal MicroShopUser User { get; }

    internal IList<string> UserRoles { get; }

    public CreateClaimsCommand(MicroShopUser user, IList<string> userRoles)
    {
        User = user;
        UserRoles = userRoles;
    }
}