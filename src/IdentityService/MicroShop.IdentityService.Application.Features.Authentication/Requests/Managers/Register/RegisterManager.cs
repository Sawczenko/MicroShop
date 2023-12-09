using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.IdentityService.Application.Features.Authentication.Models;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;

public sealed record RegisterManager : IManager<RegisterResponse>
{
    public RegisterManagerRequest Request { get; set; }

    public RegisterManager(RegisterManagerRequest request)
    {
        Request = request;
    }
}