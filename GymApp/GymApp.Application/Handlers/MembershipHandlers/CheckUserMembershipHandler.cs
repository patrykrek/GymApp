using GymApp.GymApp.Application.Queries;
using GymApp.GymApp.Application.Services.Interfaces;
using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Handlers.MembershipHandlers
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
