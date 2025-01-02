using MediatR;

namespace GymApp.Commands.MembershipCommands
{
    public record BuyMembershipCommand(int membershipId, string userId) : IRequest;
    
    
}
