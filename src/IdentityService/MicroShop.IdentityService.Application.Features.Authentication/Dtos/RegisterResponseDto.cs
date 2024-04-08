namespace MicroShop.IdentityService.Application.Features.Authentication.Dtos
{
    public class RegisterResponseDto
    {
        public bool Successful { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
