using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login;
using MicroShop.Core.Interfaces.Containers.Controllers;
using MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.IdentityService.API.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        public AuthenticationController(IControllerContainer controllerContainer) : base(controllerContainer)
        {
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginManagerRequest loginManagerRequest,
            CancellationToken cancellationToken)
        {
            return await ExecuteManager(new LoginManager(loginManagerRequest), cancellationToken);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterManagerRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteManager(new RegisterManager(request), cancellationToken);
        }
    }
}
