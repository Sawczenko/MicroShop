using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Interfaces.Requests.Query;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName
{
    internal sealed record GetUserByNameQuery : IQuery<MicroShopUser>
    {
        public string UserName { get; }

        public GetUserByNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
