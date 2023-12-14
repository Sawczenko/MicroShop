using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    public sealed record LoginManager : IManager<LoginResponseDto>
    {
        public LoginManagerRequest Request { get; }

        public LoginManager(LoginManagerRequest request)
        {
            Request = request;
        }
    }
}
