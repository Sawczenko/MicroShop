using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Abstractions.Requests.Query;
using Microsoft.AspNetCore.Identity;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName
{
    internal sealed class GetUserByNameQueryHandler : QueryHandlerBase<GetUserByNameQuery, MicroShopUser>
    {
        private readonly UserManager<MicroShopUser> _userManager;

        public GetUserByNameQueryHandler(UserManager<MicroShopUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<MicroShopUser> Handle(GetUserByNameQuery query, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(query.UserName);
        }
    }
}
