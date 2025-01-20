using MediatR;

namespace GymApp.GymApp.Application.Commands.MembershipCommands
{
    public record BuyMembershipCommand(int membershipId, string userId) : IRequest;


}
