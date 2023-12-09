using MicroShop.Core.Interfaces.Requests.Command;

namespace MicroShop.IdentityService.Application.Features.Authentication.Requests.Commands.CreateNewUser;

internal sealed record CreateNewUserCommand(string UserName, string Password, string Email) : ICommand;