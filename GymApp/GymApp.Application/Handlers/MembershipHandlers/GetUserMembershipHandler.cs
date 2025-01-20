using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.MembershipHandlers
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
