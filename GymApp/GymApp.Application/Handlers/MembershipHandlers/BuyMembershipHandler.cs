using GymApp.GymApp.Application.Commands.MembershipCommands;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.MembershipHandlers
{
    public class BuyMembershipHandler : IRequestHandler<BuyMembershipCommand>
    {
        private readonly IMembershipService _membershipService;

        public BuyMembershipHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task Handle(BuyMembershipCommand request, CancellationToken cancellationToken)
        {
            await _membershipService.BuyMembership(request.membershipId, request.userId);
        }
    }
}
