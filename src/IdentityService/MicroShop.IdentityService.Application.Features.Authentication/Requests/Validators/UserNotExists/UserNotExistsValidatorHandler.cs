using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.Core.Abstractions.Requests.Validators;
using MicroShop.Core.Models.Requests;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserNotExists;

internal sealed class UserNotExistsValidatorHandler : ValidatorHandlerBase<UserNotExistsValidator>
{
    public override async Task<RequestResult> Handle(UserNotExistsValidator validator, CancellationToken cancellationToken)
    {
        if (validator.MicroShopUser is not null)
        {
            return RequestResult.Failure(AuthenticationErrors.MICROSHOP_USER_ALREADY_EXISTS, validator.UserName);
        }

        return RequestResult.Success();
    }
}