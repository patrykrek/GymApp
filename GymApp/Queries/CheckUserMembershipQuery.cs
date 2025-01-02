using GymApp.Models;
using MediatR;

namespace GymApp.Queries
{
    public record CheckUserMembershipQuery(string userId) : IRequest<Result>;
    
    
}
