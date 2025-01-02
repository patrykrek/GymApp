using GymApp.DTO;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.MembershipHandlers
{
    public class GetUserMembershipHandler : IRequestHandler<GetUserMembershipQuery, GetUserMembershipDTO>
    {
        private readonly IMembershipService _membershipService;

        public GetUserMembershipHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<GetUserMembershipDTO> Handle(GetUserMembershipQuery request, CancellationToken cancellationToken)
        {
            return await _membershipService.GetUserMembership(request.userId);
        }
    }
}
