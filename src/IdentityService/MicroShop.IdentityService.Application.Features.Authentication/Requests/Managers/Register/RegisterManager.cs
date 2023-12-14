using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.IdentityService.Application.Features.Authentication.Dtos;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;

public sealed record RegisterManager : IManager<RegisterResponseDto>
{
    public RegisterManagerRequest Request { get; set; }

    public RegisterManager(RegisterManagerRequest request)
    {
        Request = request;
    }
}