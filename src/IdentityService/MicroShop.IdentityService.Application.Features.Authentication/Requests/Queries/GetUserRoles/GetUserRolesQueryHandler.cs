using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Abstractions.Requests.Query;
using Microsoft.AspNetCore.Identity;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserRoles;

internal sealed class GetUserRolesQueryHandler : QueryHandlerBase<GetUserRolesQuery, IList<string>> 
{
    private readonly UserManager<MicroShopUser> _userManager;

    public GetUserRolesQueryHandler(UserManager<MicroShopUser> userManager)
    {
        _userManager = userManager;
    }

    public override async Task<IList<string>> Handle(GetUserRolesQuery query, CancellationToken cancellationToken)
    {
        return await _userManager.GetRolesAsync(query.User);
    }
}