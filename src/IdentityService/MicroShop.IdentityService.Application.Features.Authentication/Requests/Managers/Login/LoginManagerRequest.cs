namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Managers.Login
{
    public sealed record LoginManagerRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
