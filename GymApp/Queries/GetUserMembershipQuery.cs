using GymApp.DTO;
using MediatR;

namespace GymApp.Queries
{
    public record GetUserMembershipQuery(string userId) : IRequest<GetUserMembershipDTO>;
    
    
}
