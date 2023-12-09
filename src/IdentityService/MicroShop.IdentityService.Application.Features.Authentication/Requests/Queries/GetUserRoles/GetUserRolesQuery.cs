using MicroShop.Core.Interfaces.Requests.Query;
using MicroShop.IdentityService.Domain.Entities.Users;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserRoles;

internal sealed record GetUserRolesQuery : IQuery<IList<string>>
{
    internal MicroShopUser User { get; }

    public GetUserRolesQuery(MicroShopUser user)
    {
        User = user;
    }
}