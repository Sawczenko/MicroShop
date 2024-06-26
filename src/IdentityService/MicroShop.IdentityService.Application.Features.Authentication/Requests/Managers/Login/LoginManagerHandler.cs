﻿using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserPassword;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateClaims;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateToken;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserRoles;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.Core.Abstractions.Requests.Manager;
using MicroShop.Core.Models.Requests;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    internal sealed class LoginManagerHandler : ManagerHandlerBase<LoginManager, LoginResponseDto>
    {
        public LoginManagerHandler(IManagerContainer container) 
            : base(container)
        {
        }

        public override async Task<RequestResult<LoginResponseDto>> Handle(LoginManager manager, CancellationToken cancellationToken)
        {
            var user = await Send(new GetUserByNameQuery(manager.Request.UserName), cancellationToken);

            var userExistsResult = await Validate(new UserExistsValidator(user, manager.Request.UserName), cancellationToken);

            if (userExistsResult.IsFailure)
            {
                return Failure(userExistsResult);
            }

            var userPasswordValidationResult = await Validate(new UserPasswordValidator(user, manager.Request), cancellationToken);

            if (userPasswordValidationResult.IsFailure)
            {
                return Failure(userPasswordValidationResult);
            }

            var userRoles = await Send(new GetUserRolesQuery(user), cancellationToken);

            var authClaimsResult = await Send(new CreateClaimsCommand(user, userRoles), cancellationToken);

            var tokenResult = await Send(new CreateTokenCommand(authClaimsResult.Result), cancellationToken);

            var loginResponse = new LoginResponseDto
            {
                Token = tokenResult.Result
            };

            return RequestResult<LoginResponseDto>.Success(loginResponse);
        }
    }
}
