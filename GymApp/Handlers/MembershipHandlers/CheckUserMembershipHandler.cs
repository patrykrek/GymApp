using GymApp.Models;
using GymApp.Queries;
using GymApp.Services.Interfaces;
using MediatR;

namespace GymApp.Handlers.MembershipHandlers
{
    public class CheckUserMembershipHandler : IRequestHandler<CheckUserMembershipQuery, Result>
    {
        private readonly IMembershipService _membershipService;

        public CheckUserMembershipHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;            
        }

        public async Task<Result> Handle(CheckUserMembershipQuery request, CancellationToken cancellationToken)
        {
            return await _membershipService.CheckUserMembership(request.userId);
        }
    }
}
