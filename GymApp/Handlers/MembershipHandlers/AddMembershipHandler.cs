using GymApp.Commands.MembershipCommands;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.MembershipHandlers
{
    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand>
    {
        private readonly IMembershipService _membershipService;

        public AddMembershipHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
            
        }

        public async Task Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            await _membershipService.AddMembership(request.membership);
        }
    }
}
