using MicroShop.Core.Abstractions.Requests.Validators;
using MicroShop.Core.Models.Exceptions;
using MicroShop.Core.Models.Requests;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserPassword;

internal sealed class UserPasswordValidatorHandler : ValidatorHandlerBase<UserPasswordValidator>
{
    private readonly UserManager<MicroShopUser> _userManager;

    public UserPasswordValidatorHandler(UserManager<MicroShopUser> _userManager)
    {
        this._userManager = _userManager;
    }

    public override async Task<RequestResult> Handle(UserPasswordValidator validator, CancellationToken cancellationToken)
    {
        var passwordMatches = await _userManager.CheckPasswordAsync(validator.MicroShopUser, validator.LoginManagerRequest.Password);

        if (!passwordMatches)
        {
            return RequestResult.Failure(AuthenticationErrors.MICROSHOP_USER_PASSWORD_IS_NOT_CORRECT, validator.LoginManagerRequest.UserName);
        }

        return RequestResult.Success();
    }
}