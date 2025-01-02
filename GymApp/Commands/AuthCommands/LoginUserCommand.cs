using GymApp.Models;
using GymApp.Models.ViewModels;
using MediatR;

namespace GymApp.Commands.AuthCommands
{
    public record LoginUserCommand(LoginViewModel model) : IRequest<Result>;


}
