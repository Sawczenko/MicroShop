using MicroShop.IdentityService.Application.Features.Authentication.Models;
using MicroShop.Core.Interfaces.Requests.Manager;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    public sealed record LoginManager : IManager<LoginResponse>
    {
        public LoginManagerRequest LoginManagerRequest;

        public LoginManager(LoginManagerRequest loginManagerRequest)
        {
            LoginManagerRequest = loginManagerRequest;
        }
    }
}
