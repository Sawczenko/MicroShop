using MicroShop.Core.Abstractions.Requests.Command;
using MicroShop.Core.Models.Requests;
using MicroShop.IdentityService.Application.Errors.Authentication;
using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateNewUser;

internal sealed class CreateNewUserCommandHandler : CommandHandlerBase<CreateNewUserCommand>
{
    private readonly UserManager<MicroShopUser> _userManager;

    public CreateNewUserCommandHandler(UserManager<MicroShopUser> userManager)
    {
        _userManager = userManager;
    }

    public override async Task<RequestResult> Handle(CreateNewUserCommand command, CancellationToken cancellationToken)
    {
        MicroShopUser user = new MicroShopUser()
        {
            Email = command.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = command.UserName
        };


        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return RequestResult.Failure(AuthenticationErrors.MICROSHOP_USER_CREATION_FAILED);
        }

        return RequestResult.Success();
    }
}