using MicroShop.Core.Abstractions.Requests.ResponseCommand;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MicroShop.Core.Models.Requests;
using System.Text;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateToken;

internal sealed class CreateTokenCommandHandler : CommandHandlerBase<CreateTokenCommand, string>
{
    private readonly IConfiguration _configuration;

    public CreateTokenCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override async Task<RequestResult<string>> Handle(CreateTokenCommand command, CancellationToken cancellationToken)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: command.Claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return await Task.FromResult(RequestResult<string>.Success(jwtToken));
    }
}