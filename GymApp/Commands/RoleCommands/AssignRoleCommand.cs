using GymApp.Models;
using MediatR;

namespace GymApp.Commands.RoleCommands
{
    public record AssignRoleCommand(UserRole user) : IRequest;
    
    
}
