using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Commands.RoleCommands
{
    public record AssignRoleCommand(UserRole user) : IRequest;


}
