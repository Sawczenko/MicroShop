namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Register;

public sealed record RegisterManagerRequest
{
    public string UserName { get; set; }  = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}