using MicroShop.IdentityService.Application.Features.Authentication.Requests.Validators.UserExists;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Queries.GetUserByName;
using MicroShop.IdentityService.Application.Features.Authentication.Models;
using MicroShop.Core.Interfaces.Containers.Requests.Manager;
using MicroShop.IdentityService.Domain.Entities.Users;
using MicroShop.Core.Abstractions.Requests.Manager;
using Microsoft.AspNetCore.Identity;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    internal sealed class LoginManagerHandler : ManagerHandlerBase<LoginManager, LoginResponse>
    {
        private readonly UserManager<MicroShopUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public LoginManagerHandler(IManagerContainer container, 
            UserManager<MicroShopUser> userManager,
            RoleManager<IdentityRole<int>> roleManager) 
            : base(container)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task<LoginResponse> Handle(LoginManager manager, CancellationToken cancellationToken)
        {
            var user = await Send(new GetUserByNameQuery(manager.LoginManagerRequest.UserName), cancellationToken);

            await Validate(new UserExistsValidator(user, manager.LoginManagerRequest.UserName), cancellationToken);

            return default;
        }
    }
}
