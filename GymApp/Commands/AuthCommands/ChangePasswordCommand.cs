using GymApp.DTO;
using GymApp.Models;
using MediatR;

namespace GymApp.Commands.AuthCommands
{
    public record ChangePasswordCommand(ChangePasswordDTO request) : IRequest<Result>;
    
    
}
