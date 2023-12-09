using MicroShop.Core.Interfaces.Requests.Validator;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login;
using MicroShop.IdentityService.Domain.Entities.Users;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserPassword;

internal sealed record UserPasswordValidator : IValidator
{

    internal MicroShopUser MicroShopUser { get; }

    internal LoginManagerRequest LoginManagerRequest { get; }

    public UserPasswordValidator(MicroShopUser microShopUser, LoginManagerRequest loginManagerRequest)
    {
        MicroShopUser = microShopUser;
        LoginManagerRequest = loginManagerRequest;
    }
}