using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.Core.Abstractions.Requests.Validators;
using MicroShop.Core.Models.Exceptions;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;

internal sealed class UserExistsValidatorHandler : ValidatorHandlerBase<UserExistsValidator>
{
    public override Task<bool> Handle(UserExistsValidator validator, CancellationToken cancellationToken)
    {
        if (validator.MicroShopUser is null)
        {
            throw RequestException.CreateParametrized(AuthenticationErrors.MICROSHOP_USER_DOES_NOT_EXIST, validator.UserName);
        }

        return Task.FromResult(true);
    }
}