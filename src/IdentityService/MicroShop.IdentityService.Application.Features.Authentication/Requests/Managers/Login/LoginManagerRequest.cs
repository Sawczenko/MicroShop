namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    public sealed record LoginManagerRequest
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
