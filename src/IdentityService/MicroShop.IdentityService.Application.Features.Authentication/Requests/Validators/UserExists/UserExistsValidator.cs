using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Interfaces.Requests.Validator;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;

internal sealed record UserExistsValidator : IValidator
{
    public MicroShopUser MicroShopUser { get; }
    public string UserName { get; }

    public UserExistsValidator(MicroShopUser microShopUser, string userName)
    {
        MicroShopUser = microShopUser;
        UserName = userName;
    }
}