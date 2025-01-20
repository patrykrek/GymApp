using GymApp.GymApp.Application.DTO;
using MediatR;

namespace GymApp.GymApp.Application.Commands.MembershipCommands
{
    public record AddMembershipCommand(AddMembershipDTO membership) : IRequest;



}
