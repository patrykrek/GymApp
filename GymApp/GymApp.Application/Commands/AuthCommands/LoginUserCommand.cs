using GymApp.GymApp.Domain.Models;
using GymApp.GymApp.Domain.Models.ViewModels;
using MediatR;

namespace GymApp.GymApp.Application.Commands.AuthCommands
{
    public record LoginUserCommand(LoginViewModel model) : IRequest<Result>;


}
