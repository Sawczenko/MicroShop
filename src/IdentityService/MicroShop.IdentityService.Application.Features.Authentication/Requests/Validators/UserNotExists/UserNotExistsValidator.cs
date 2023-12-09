using MicroShop.Core.Interfaces.Requests.Validator;
using MicroShop.IdentityService.Domain.Entities.Users;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserNotExists;
internal sealed record UserNotExistsValidator : IValidator
{
    public MicroShopUser MicroShopUser { get; }
    public string UserName { get; }

    public UserNotExistsValidator(MicroShopUser microShopUser, string userName)
    {
        MicroShopUser = microShopUser;
        UserName = userName;
    }
}