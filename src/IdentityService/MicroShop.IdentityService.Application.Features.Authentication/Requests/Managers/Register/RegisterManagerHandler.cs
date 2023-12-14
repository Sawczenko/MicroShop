using MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateNewUser;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserNotExists;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;

internal sealed class RegisterManagerHandler : ManagerHandlerBase<RegisterManager, RegisterResponseDto>
{
    public RegisterManagerHandler(IManagerContainer container) 
        : base(container) { }

    public override async Task<RequestResult<RegisterResponseDto>> Handle(RegisterManager manager, CancellationToken cancellationToken)
    {
        var existingUser = await Send(new GetUserByNameQuery(manager.Request.UserName), cancellationToken);

        var userExistsResult = await Validate(new UserNotExistsValidator(existingUser, manager.Request.UserName), cancellationToken);

        if (userExistsResult.IsFailure)
        {
            return Failure(userExistsResult);
        }

        var userCreationResult = await Send(new CreateNewUserCommand(manager.Request.UserName, manager.Request.Password,
            manager.Request.Email), cancellationToken);

        if (userCreationResult.IsFailure)
        {
            return Failure(userCreationResult);
        }

        return RequestResult<RegisterResponseDto>.Success(new RegisterResponseDto
        {
            Message = "User created Successfully!",
            Successful = true
        });
    }
}