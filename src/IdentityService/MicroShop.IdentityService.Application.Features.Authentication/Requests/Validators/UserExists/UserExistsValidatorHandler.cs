using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.Core.Abstractions.Requests.Validators;
using MicroShop.Core.Models.Requests;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;

internal sealed class UserExistsValidatorHandler : ValidatorHandlerBase<UserExistsValidator>
{
    public override Task<RequestResult> Handle(UserExistsValidator validator, CancellationToken cancellationToken)
    {
        if (validator.MicroShopUser is null)
        {
            return Task.FromResult(RequestResult.Failure(AuthenticationErrors.MICROSHOP_USER_DOES_NOT_EXIST, validator.UserName));
        }

        return Task.FromResult(RequestResult.Success());
    }
}