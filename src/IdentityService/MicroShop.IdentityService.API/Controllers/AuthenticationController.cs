using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.IdentityService.API.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        public AuthenticationController(IControllerContainer controllerContainer) : base(controllerContainer)
        {
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginManagerRequest loginManagerRequest,
            CancellationToken cancellationToken)
        {
            return await ExecuteManager(new LoginManager(loginManagerRequest), cancellationToken);
        }
    }
}
