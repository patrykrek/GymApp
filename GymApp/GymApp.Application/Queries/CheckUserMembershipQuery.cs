using GymApp.GymApp.Domain.Models;
using MediatR;

namespace GymApp.GymApp.Application.Queries
{
    public record CheckUserMembershipQuery(string userId) : IRequest<Result>;


}
