using GymApp.DTO;
using MediatR;

namespace GymApp.Commands.MembershipCommands
{
    public record AddMembershipCommand(AddMembershipDTO membership) : IRequest;
    

    
}
