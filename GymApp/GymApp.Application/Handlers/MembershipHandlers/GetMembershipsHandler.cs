using GymApp.GymApp.Application.DTO;
using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.MembershipHandlers
{
    public class GetMembershipsHandler : IRequestHandler<GetMembershipsQuery, List<GetMembershipsDTO>>
    {
        private readonly IMembershipService _membershipService;

        public GetMembershipsHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<List<GetMembershipsDTO>> Handle(GetMembershipsQuery request, CancellationToken cancellationToken)
        {
            return await _membershipService.GetMemberships();
        }
    }
}
