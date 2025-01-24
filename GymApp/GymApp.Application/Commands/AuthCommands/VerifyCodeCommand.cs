using MediatR;

namespace GymApp.GymApp.Application.Commands.AuthCommands
{
    public record VerifyCodeCommand(string UserId, int code) : IRequest<bool>;
    
    
}
